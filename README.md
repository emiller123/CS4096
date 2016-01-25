# CS4096
# Senior Design Project



========================================
tsharesim: taxi ride sharing simulator
========================================

tsharesim simulates a taxi system that dynamically reacts to customer requests. A configurable number of taxis travel along a predefined road network; the simulator attempts to assign new requests (which could come in from a website or a phone system) to a taxi, in such a way that ride sharing is maximized. Ride sharing, where the requests of multiple passengers are combined into one road trip, can save significant amounts of fuel, and also greatly reduce traffic congestion.

The simulation ensures that two constraints are satisfied for every customer. First, that the time from when the request is submitted to when the passenger is picked up will be less than some pickup constraint (PICKUP_CONST). Second, that the factor by which the trip from the request's source to the request's destination is extended is no greater than some service constraint (SERVICE_CONST). An example for the second constraint: if the shortest distance from the source to destination is 5.0, and the service constraint is 1.5, then the taxi will not detour more than 2.5 units AFTER the passenger is picked up. Thus, for a request from A to B, the total time from when the request is received to when the passenger is _dropped off_ will be no greater than PICKUP_CONST + SERVICE_CONST * shortest_distance(A, B).

Additionally, all taxis have a specific capacity (MAX_PASSENGERS). This is the maximum number of passengers that can be assigned to the taxi at once. Note that even if the assigned passengers are picked up and then dropped off sequentially, the maximum still applies: it is on the number of _assigned_ passengers, not the number of passengers currently actually in the taxi.

Requests are read from a file and specify a source and destination vertex, along with the time at which the request will be submitted into the simulator. The simulator then notifies taxis near the request's source, and each notified taxi attempts to add the request to its current route and then returns whether the taxi can satisfy the request (considering constraints and their capacity); if the taxi is able to satisfy the request, the taxi also returns the length of the shortest route that will drop off all passengers currently assigned to the taxi, along with the new request. In the simulator, if no taxis are able to satisfy the request, then the request is rejected. Otherwise, the request is assigned to the taxi with the shortest shortest-route. Once a request is assigned to a taxi, it cannot be un-assigned; that is, the taxi must pickup and then drop off that passenger.

Having MAX_PASSENGERS=1 is essentially the same as removing the ride sharing feature.

There are several algorithms that can be used to determine the shortest route in the taxi:

- Branch and bound (ALGORITHM=0): branch and bound.
- Brute force (ALGORITHM=1): brute force approach.
- Mixed integer programming (ALGORITHM=2): problem is represented as a mixed-integer programming model, and solved using the lpsolve library.
- Tree algorithms (ALGORITHM=3 to 5): these are our focus. A tree is created to represent all feasible paths, and is extended whenever a new request comes in. This is the only incremental algorithm: for the others, with each new request the existing data is not reused. The shortest path from root to leaf node in the tree is the shortest route.

Configuration
-------------

Configuration is accomplished mostly in the top of simulator.cpp. MAX_PASSENGERS, MAX_TAXIS, and ALGORITHM can be set through arguments, so do not need to be modified; an argument can also be used to scale the PICKUP_CONST and SERVICE_CONST constraint settings. HASHINGLONG and HASHINGLAT are 1000000 times the smallest X-axis and Y-axis vertex, respectively. D is the constant taxi speed. logicalTime and logicalTimeLimit define the starting and ending time for the simulation.

Road network format
-------------------

There are three files required for the road network to be properly read: vertices.out, edges.out, and edges.gra. These should all reside in the inDirectory defined in simulator.cpp.

vertices.out: the first line should contain the number of vertices in the file. The ith line should contain two numbers, delimited by a space: a longitude and a latitude (or however you are defining the X and Y axes). This is the location of the (i-1)th vertex, which has a ID of i-2 (the vertex ID's are zero-based).

edges.out: the first line should contain the number of edges in the file. Each subsequent line should contain three numbers, delimited by spaces: two vertex ID's, and a floating point distance between them. This defines an edge with a set distance between the two specified vertices.

edges.gra: the first line should contain the number of vertices in the graph. The ith line should contain:
	(vertex ID): (neighbor ID) (distance) (neighbor ID) (distance) ...
	For example, if the third vertex is connected to the first with distance 5.0 and the second with distance 7.5, the line would be:
	3: 1 5.0 2 7.5

The .gra file can be generated from the .out files using one of the included utilities (see util/Convert.java or util/GraphUtil.java).

Request format
--------------

Requests are read from {inDirectory}/newtaxi.dat.

Each line is tab-delimited and contains three integers that represent one request. These integers are, in order, the simulation time (see logicalTime in configuration) at which the request is submitted, the source vertex ID, and the destination vertex ID.

Citations
---------

Please use the following citations when using the codes:

1. Charles Tian, Yan Huang, Zhi Liu, Favyen Bastani, Ruoming Jin: Noah: a dynamic ridesharing system. SIGMOD Conference 2013: 985-988
@inproceedings{DBLP:conf/sigmod/TianHLBJ13,
  author    = {Charles Tian and
               Yan Huang and
               Zhi Liu and
               Favyen Bastani and
               Ruoming Jin},
  title     = {Noah: a dynamic ridesharing system},
  booktitle = {Proceedings of the {ACM} {SIGMOD} International Conference on Management
               of Data, {SIGMOD} 2013, New York, NY, USA, June 22-27, 2013},
  year      = {2013},
  pages     = {985--988},
}

2. Yan Huang, Favyen Bastani, Ruoming Jin, Xiaoyang Sean Wang: Large Scale Real-time Ridesharing with Service Guarantee on Road Networks. PVLDB 7(14): 2017-2028 (2014)
@article{DBLP:journals/pvldb/HuangBJW14,
  author    = {Yan Huang and
               Favyen Bastani and
               Ruoming Jin and
               Xiaoyang Sean Wang},
  title     = {Large Scale Real-time Ridesharing with Service Guarantee on Road Networks},
  journal   = {{PVLDB}},
  year      = {2014},
  volume    = {7},
  number    = {14},
  pages     = {2017--2028}
}
