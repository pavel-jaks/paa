# Results

## The notes

* We implemented several algorithms to solve sudoku boards.
* Baseline algorithm is DFS implemented via recursion.
	* On board called DfsBreaker, almost a minute to solve the problem.
* Enhanced version taken as DFS with heuristic takes much less time on this problem.
	* CspSolver is taken as the state-of-the-art sequential solver.
* Parallel version of search is sadly BFS, which uses very much more memory,
so it's unusable.
* Hence, we implemented basically sequential Csp solver with parallel subroutines
* The algorithms are measured on 4 different sudokus.

### Efficiency table

*E = T_S / T_P*

| Board | Release | Debug |
| ----- | ---: | ---: |
|Empty| 0,25 |0,41|
|Hard| 0,18|0,21 |
|Deep| 0,20| 0,24|
|DfsBreaker| 0,095| 0,084|

### Speedup table

*S = E / p*

| Board | Release | Debug |
| ----- | ---: | ---: |
|Empty| 2,01 |3,28|
|Hard| 1,43|1,65 |
|Deep| 1,57| 1,95|
|DfsBreaker| 0,76| 0,67|

## Data

### SimpleBacktrackingSolver

1. 180,91 s (Debug)
2. 57,85 s (Release)

In the following, we list the measurements of times
taken of CspSolver (= Sequential) and ParallelCspSolver (= Parallel)

### DfsBreaker

#### Debug:

Sequential 1 run: 3,5770095
Sequential 2 run: 3,3188086
Sequential 3 run: 3,2745506
Sequential 4 run: 3,2102465
Sequential 5 run: 3,1867635
Sequential 6 run: 3,1954151
Sequential 7 run: 3,1192415
Sequential 8 run: 3,1293226
Sequential 9 run: 3,1474242
Sequential 10 run: 3,0795579
Parallel 1 run: 8,8129644
Parallel 2 run: 2,1873077
Parallel 3 run: 5,41174
Parallel 4 run: 2,1224603
Parallel 5 run: 7,0389349
Parallel 6 run: 3,5537856
Parallel 7 run: 10,0912211
Parallel 8 run: 3,6527926
Parallel 9 run: 2,6972213
Parallel 10 run: 2,3440255
Csp time: 3,223834
ParallelCsp time: 4,791245340000001

- S = 0,67
- E = 0,084


#### Release:

Sequential 1 run: 2,5617563
Sequential 2 run: 2,1186975
Sequential 3 run: 2,080662
Sequential 4 run: 2,1126864
Sequential 5 run: 2,0428129
Sequential 6 run: 1,9832842
Sequential 7 run: 1,9918517
Sequential 8 run: 1,9822516
Sequential 9 run: 1,9898132
Sequential 10 run: 1,9584704
Parallel 1 run: 3,3957451
Parallel 2 run: 2,7907423
Parallel 3 run: 1,374475
Parallel 4 run: 1,734071
Parallel 5 run: 7,8125593
Parallel 6 run: 1,1647782
Parallel 7 run: 3,028384
Parallel 8 run: 1,5201607
Parallel 9 run: 2,705501
Parallel 10 run: 1,8285579
Csp time: 2,08222862
ParallelCsp time: 2,7354974499999996

- S = 0,76
- E = 0,095

### Hard

#### Debug

Sequential 1 run: 0,4397685
Sequential 2 run: 0,2470318
Sequential 3 run: 0,2446634
Sequential 4 run: 0,2312334
Sequential 5 run: 0,2190227
Sequential 6 run: 0,2175353
Sequential 7 run: 0,2220977
Sequential 8 run: 0,2204186
Sequential 9 run: 0,2197703
Sequential 10 run: 0,2219995
Parallel 1 run: 0,2414884
Parallel 2 run: 0,1373179
Parallel 3 run: 0,1483217
Parallel 4 run: 0,1799166
Parallel 5 run: 0,2092968
Parallel 6 run: 0,1401023
Parallel 7 run: 0,0445879
Parallel 8 run: 0,041166
Parallel 9 run: 0,3297008
Parallel 10 run: 0,0338915
Csp time: 0,24835411999999998
ParallelCsp time: 0,15057899000000002

- S = 1,65
- E = 0,21

#### Release

Sequential 1 run: 0,4991292
Sequential 2 run: 0,1689646
Sequential 3 run: 0,161065
Sequential 4 run: 0,1609091
Sequential 5 run: 0,1465042
Sequential 6 run: 0,1548738
Sequential 7 run: 0,1479468
Sequential 8 run: 0,1493011
Sequential 9 run: 0,1375434
Sequential 10 run: 0,1401014
Parallel 1 run: 0,117129
Parallel 2 run: 0,1868062
Parallel 3 run: 0,1352848
Parallel 4 run: 0,128707
Parallel 5 run: 0,1212728
Parallel 6 run: 0,1160412
Parallel 7 run: 0,0189277
Parallel 8 run: 0,1430623
Parallel 9 run: 0,1731081
Parallel 10 run: 0,1624725
Csp time: 0,18663385999999998
ParallelCsp time: 0,13028115999999998

- S = 1,43
- E = 0,18

### Empty

#### Debug

Sequential 1 run: 0,3337715
Sequential 2 run: 0,2580269
Sequential 3 run: 0,1296474
Sequential 4 run: 0,0601956
Sequential 5 run: 0,0618302
Sequential 6 run: 0,0627391
Sequential 7 run: 0,0532119
Sequential 8 run: 0,0533222
Sequential 9 run: 0,0528365
Sequential 10 run: 0,0576168
Parallel 1 run: 0,1037511
Parallel 2 run: 0,033936
Parallel 3 run: 0,0312744
Parallel 4 run: 0,0297754
Parallel 5 run: 0,0310012
Parallel 6 run: 0,0279892
Parallel 7 run: 0,0360813
Parallel 8 run: 0,0315523
Parallel 9 run: 0,0274688
Parallel 10 run: 0,0313769
Csp time: 0,11231980999999999
ParallelCsp time: 0,03842066

- S = 3,28
- E = 0,41

#### Release

Sequential 1 run: 0,223091
Sequential 2 run: 0,19212
Sequential 3 run: 0,119407
Sequential 4 run: 0,0425299
Sequential 5 run: 0,036217
Sequential 6 run: 0,043714
Sequential 7 run: 0,0391536
Sequential 8 run: 0,0390319
Sequential 9 run: 0,0360624
Sequential 10 run: 0,0396948
Parallel 1 run: 0,1243119
Parallel 2 run: 0,0324428
Parallel 3 run: 0,0323807
Parallel 4 run: 0,032775
Parallel 5 run: 0,0265788
Parallel 6 run: 0,034005
Parallel 7 run: 0,0274472
Parallel 8 run: 0,0319346
Parallel 9 run: 0,0309025
Parallel 10 run: 0,0302222
Csp time: 0,08110216000000002
ParallelCsp time: 0,04030007

- S = 2,01
- E = 0,25

### Deep

#### Debug

Sequential 1 run: 0,2144814
Sequential 2 run: 0,1174406
Sequential 3 run: 0,1040488
Sequential 4 run: 0,0561694
Sequential 5 run: 0,0452023
Sequential 6 run: 0,0456894
Sequential 7 run: 0,0499379
Sequential 8 run: 0,0498054
Sequential 9 run: 0,0481246
Sequential 10 run: 0,0481884
Parallel 1 run: 0,1067081
Parallel 2 run: 0,0358207
Parallel 3 run: 0,0297326
Parallel 4 run: 0,0283621
Parallel 5 run: 0,0325006
Parallel 6 run: 0,0337557
Parallel 7 run: 0,0300392
Parallel 8 run: 0,0324944
Parallel 9 run: 0,0371973
Parallel 10 run: 0,0320543
Csp time: 0,07790881999999999
ParallelCsp time: 0,03986649999999999

- S = 1,95
- E = 0,24

#### Release

Sequential 1 run: 0,1872965
Sequential 2 run: 0,1588223
Sequential 3 run: 0,1453981
Sequential 4 run: 0,0781495
Sequential 5 run: 0,0420305
Sequential 6 run: 0,0386632
Sequential 7 run: 0,0353518
Sequential 8 run: 0,0321737
Sequential 9 run: 0,0299061
Sequential 10 run: 0,0257239
Parallel 1 run: 0,1883161
Parallel 2 run: 0,0347669
Parallel 3 run: 0,0437453
Parallel 4 run: 0,0377693
Parallel 5 run: 0,0348704
Parallel 6 run: 0,0334912
Parallel 7 run: 0,027135
Parallel 8 run: 0,0295056
Parallel 9 run: 0,0254792
Parallel 10 run: 0,0367055
Csp time: 0,07735156000000001
ParallelCsp time: 0,04917845

- S = 1,57
- E = 0,20
