 ### Other egines tested against:

| Name | Version | ELO (CCRL 4040) | URL
| --- | --- | --- | --- |
| JW's "Tier 2" | - | - | https://github.com/jw1912/Chess-Challenge/blob/example/Chess-Challenge/src/My%20Bot/MyBot.cs |
| Vice | 1.1 | 2094 | https://ccrl.chessdom.com/ccrl/4040/cgi/engine_details.cgi?print=Details&each_game=0&eng=Vice%201.0%2064-bit#Vice_1_0_64-bit |
| Kimbo | 1.0 | 2473 | https://github.com/jw1912/Kimbo/releases/tag/v1.0.0 |
| 4ku | 1.1 | 2547 | https://github.com/kz04px/4ku/releases/tag/v1.1 |

### Tools used:
 * CuteChess: https://github.com/cutechess/cutechess/releases/tag/v1.3.1
 * My own texel tuner: https://github.com/GediminasMasaitis/texel-tuner
 * Chess tuning tools: https://chess-tuning-tools.readthedocs.io/en/latest/

### 1.0
Initial release - random legal mover

53 tokens

```
Score of ChessChallenge1.0 vs ChessChallengeEvil: 2 - 4211 - 787  [0.079] 5000
...      ChessChallenge1.0 playing White: 2 - 2081 - 416  [0.084] 2499
...      ChessChallenge1.0 playing Black: 0 - 2130 - 371  [0.074] 2501
...      White vs Black: 2132 - 2081 - 787  [0.505] 5000
Elo difference: -426.4 +/- 12.1, LOS: 0.0 %, DrawRatio: 15.7 %
```

### 1.1
Basics for a searching engine:
* Iterative deepening
* Brute-force search
* Basic time tracking
* Material-only evaluation
* Mate and stalemate detection

329 tokens (+276)

```
Score of ChessChallenge1.1 vs ChessChallenge1.0: 1783 - 0 - 217  [0.946] 2000
...      ChessChallenge1.1 playing White: 886 - 0 - 114  [0.943] 1000
...      ChessChallenge1.1 playing Black: 897 - 0 - 103  [0.949] 1000
...      White vs Black: 886 - 897 - 217  [0.497] 2000
Elo difference: 496.6 +/- 23.2, LOS: 100.0 %, DrawRatio: 10.8 %

Score of ChessChallenge1.1 vs ChessChallengeEvil: 1667 - 0 - 333  [0.917] 2000
...      ChessChallenge1.1 playing White: 828 - 0 - 171  [0.914] 999
...      ChessChallenge1.1 playing Black: 839 - 0 - 162  [0.919] 1001
...      White vs Black: 828 - 839 - 333  [0.497] 2000
Elo difference: 416.7 +/- 18.6, LOS: 100.0 %, DrawRatio: 16.7 %
```

### 1.2
Centrality evaluation

383 tokens (+54)

```
Score of ChessChallenge vs ChessChallengeDev: 338 - 81 - 1581  [0.564] 2000
...      ChessChallenge playing White: 189 - 33 - 778  [0.578] 1000
...      ChessChallenge playing Black: 149 - 48 - 803  [0.550] 1000
...      White vs Black: 237 - 182 - 1581  [0.514] 2000
Elo difference: 44.9 +/- 6.8, LOS: 100.0 %, DrawRatio: 79.0 %
```

### 1.3
Poor man's repetition detection

448 tokens (+65)

```
Score of ChessChallenge vs ChessChallengeDev: 272 - 143 - 585  [0.565] 1000
...      ChessChallenge playing White: 126 - 75 - 300  [0.551] 501
...      ChessChallenge playing Black: 146 - 68 - 285  [0.578] 499
...      White vs Black: 194 - 221 - 585  [0.486] 1000
Elo difference: 45.1 +/- 13.8, LOS: 100.0 %, DrawRatio: 58.5 %

Score of ChessChallenge vs ChessChallengeEvil: 1902 - 0 - 98  [0.976] 2000
...      ChessChallenge playing White: 932 - 0 - 68  [0.966] 1000
...      ChessChallenge playing Black: 970 - 0 - 30  [0.985] 1000
...      White vs Black: 932 - 970 - 98  [0.490] 2000
Elo difference: 640.0 +/- 34.8, LOS: 100.0 %, DrawRatio: 4.9 %
```

### 1.4
Alpha-beta pruning

506 tokens (+58)

```
Score of ChessChallenge vs ChessChallengeDev: 730 - 39 - 231  [0.846] 1000
...      ChessChallenge playing White: 353 - 14 - 133  [0.839] 500
...      ChessChallenge playing Black: 377 - 25 - 98  [0.852] 500
...      White vs Black: 378 - 391 - 231  [0.493] 1000
Elo difference: 295.3 +/- 22.3, LOS: 100.0 %, DrawRatio: 23.1 %
```

### 1.5
Order capture moves first

521 tokens (+15)

```
Score of ChessChallenge vs ChessChallengeDev: 549 - 104 - 347  [0.723] 1000
...      ChessChallenge playing White: 289 - 50 - 162  [0.739] 501
...      ChessChallenge playing Black: 260 - 54 - 185  [0.706] 499
...      White vs Black: 343 - 310 - 347  [0.516] 1000
Elo difference: 166.2 +/- 18.1, LOS: 100.0 %, DrawRatio: 34.7 %
```

### 1.5.1
Remove unused usings

503 tokens (-18)

### 1.6
Sort by most valuable victim - least valuable attacker

Implemented by Goh CJ (cj5716)

516 tokens (+13)

```
Score of ChessChallenge vs ChessChallengeDev: 539 - 364 - 97
Elo difference: 61 +/- 21
```

### 1.7
Evaluation changes:
* Evaluation texel tuning using https://github.com/GediminasMasaitis/texel-tuner
* Remove centrality evaluation
* Split PSTs by rank and file

566 tokens (+50)

```
Score of ChessChallenge vs ChessChallengeDev: 811 - 424 - 265  [0.629] 1500
...      ChessChallenge playing White: 395 - 211 - 144  [0.623] 750
...      ChessChallenge playing Black: 416 - 213 - 121  [0.635] 750
...      White vs Black: 608 - 627 - 265  [0.494] 1500
Elo difference: 91.7 +/- 16.4, LOS: 100.0 %, DrawRatio: 17.7 %

Score of ChessChallenge vs ChessChallengeEvil: 4891 - 0 - 109  [0.989] 5000
...      ChessChallenge playing White: 2432 - 0 - 69  [0.986] 2501
...      ChessChallenge playing Black: 2459 - 0 - 40  [0.992] 2499
...      White vs Black: 2432 - 2459 - 109  [0.497] 5000
Elo difference: 783.1 +/- 32.9, LOS: 100.0 %, DrawRatio: 2.2 %
```

### 1.7.1
Format output to be semi UCI compatible, add more info to it

593 tokens (+27)

```
info depth 1 cp 56 time 31 Move: 'g1f3'
info depth 2 cp 0 time 32 Move: 'g1f3'
info depth 3 cp 50 time 34 Move: 'b1c3'
info depth 4 cp 0 time 62 Move: 'b1c3'
info depth 5 cp 89 time 187 Move: 'b2b3'
info depth 6 cp -39 time 1381 Move: 'b1c3'
info depth 7 cp 117 time 7861 Move: 'e2e3'
```

### 1.8
Add qsearch when depth <= 0

Implemented by Goh CJ (cj5716)

614 tokens (+21)

```
info depth 1 cp 56 time 32 Move: 'g1f3'
info depth 2 cp 0 time 34 Move: 'g1f3'
info depth 3 cp 50 time 38 Move: 'b1c3'
info depth 4 cp 0 time 101 Move: 'b1c3'
info depth 5 cp 12 time 1008 Move: 'b1a3'
info depth 6 cp 0 time 8181 Move: 'b1c3'
```

```
Score of ChessChallenge vs ChessChallengeDev: 1215 - 138 - 147  [0.859] 1500
...      ChessChallenge playing White: 628 - 52 - 71  [0.883] 751
...      ChessChallenge playing Black: 587 - 86 - 76  [0.834] 749
...      White vs Black: 714 - 639 - 147  [0.525] 1500
Elo difference: 313.9 +/- 22.6, LOS: 100.0 %, DrawRatio: 9.8 %

Score of ChessChallenge vs ChessChallengeEvil: 4924 - 0 - 76  [0.992] 5000
...      ChessChallenge playing White: 2458 - 0 - 43  [0.991] 2501
...      ChessChallenge playing Black: 2466 - 0 - 33  [0.993] 2499
...      White vs Black: 2458 - 2466 - 76  [0.499] 5000
Elo difference: 846.3 +/- 39.7, LOS: 100.0 %, DrawRatio: 1.5 %
```

### 1.9
Faster and smaller MVV-LVA ordering

602 tokens (-12)

```
info depth 1 cp 56 time 0 Move: 'g1f3'
info depth 2 cp 0 time 0 Move: 'g1f3'
info depth 3 cp 50 time 3 Move: 'b1c3'
info depth 4 cp 0 time 55 Move: 'b1c3'
info depth 5 cp 12 time 846 Move: 'b1a3'
info depth 6 cp 0 time 6837 Move: 'b1c3'
```

```
Score of ChessChallenge vs ChessChallengeDev: 934 - 680 - 386  [0.564] 2000
...      ChessChallenge playing White: 519 - 298 - 183  [0.611] 1000
...      ChessChallenge playing Black: 415 - 382 - 203  [0.516] 1000
...      White vs Black: 901 - 713 - 386  [0.547] 2000
Elo difference: 44.4 +/- 13.8, LOS: 100.0 %, DrawRatio: 19.3 %
```

### 1.10
In-check extension

610 tokens (+8)

```
info depth 1 cp 56 time 32 Move: 'g1f3'
info depth 2 cp 0 time 34 Move: 'g1f3'
info depth 3 cp 50 time 38 Move: 'b1c3'
info depth 4 cp 0 time 96 Move: 'b1c3'
info depth 5 cp 12 time 916 Move: 'b1a3'
bestmove b1a3
```

```
Score of ChessChallenge vs ChessChallengeDev: 771 - 405 - 324  [0.622] 1500
...      ChessChallenge playing White: 408 - 169 - 172  [0.660] 749
...      ChessChallenge playing Black: 363 - 236 - 152  [0.585] 751
...      White vs Black: 644 - 532 - 324  [0.537] 1500
Elo difference: 86.5 +/- 15.9, LOS: 100.0 %, DrawRatio: 21.6 %
```


### 1.11
Use built-in API for repetition detections

570 tokens (-40)

```
info depth 1 cp 56 time 28 Move: 'g1f3'
info depth 2 cp 0 time 29 Move: 'g1f3'
info depth 3 cp 50 time 33 Move: 'b1c3'
info depth 4 cp 0 time 88 Move: 'b1c3'
info depth 5 cp 12 time 878 Move: 'b1a3'
bestmove b1a3
```

```
Score of ChessChallenge vs ChessChallengeDev: 1113 - 1074 - 813  [0.506] 3000
...      ChessChallenge playing White: 660 - 447 - 393  [0.571] 1500
...      ChessChallenge playing Black: 453 - 627 - 420  [0.442] 1500
...      White vs Black: 1287 - 900 - 813  [0.565] 3000
Elo difference: 4.5 +/- 10.6, LOS: 79.8 %, DrawRatio: 27.1 %
```

### 1.12
Primitive transposition table, only used for move ordering best known move first

631 tokens (+61)

```
info depth 1 cp 56 time 32 Move: 'g1f3'
info depth 2 cp 0 time 34 Move: 'g1f3'
info depth 3 cp 50 time 39 Move: 'g1f3'
info depth 4 cp 0 time 45 Move: 'g1f3'
info depth 5 cp 12 time 171 Move: 'g1f3'
info depth 6 cp 0 time 254 Move: 'g1f3'
bestmove g1f3
```

```
Score of ChessChallenge vs ChessChallengeDev: 738 - 375 - 387  [0.621] 1500
...      ChessChallenge playing White: 425 - 147 - 179  [0.685] 751
...      ChessChallenge playing Black: 313 - 228 - 208  [0.557] 749
...      White vs Black: 653 - 460 - 387  [0.564] 1500
Elo difference: 85.8 +/- 15.4, LOS: 100.0 %, DrawRatio: 25.8 %
```

### 1.12.1
Mark #DEBUG code

593 tokens (-38)

### 1.13
Faster move ordering

593 tokens (=)

```
info depth 1 cp 56 time 29 Move: 'g1f3'
info depth 2 cp 0 time 31 Move: 'g1f3'
info depth 3 cp 50 time 36 Move: 'g1f3'
info depth 4 cp 0 time 40 Move: 'g1f3'
info depth 5 cp 12 time 142 Move: 'g1f3'
info depth 6 cp 0 time 203 Move: 'g1f3'
bestmove g1f3
```

```
Score of ChessChallenge vs ChessChallengeDev: 929 - 660 - 411  [0.567] 2000
...      ChessChallenge playing White: 530 - 252 - 219  [0.639] 1001
...      ChessChallenge playing Black: 399 - 408 - 192  [0.495] 999
...      White vs Black: 938 - 651 - 411  [0.572] 2000
Elo difference: 47.0 +/- 13.7, LOS: 100.0 %, DrawRatio: 20.5 %
```

### 1.14
Move generation and ordering after qsearch checks

593 tokens (=)

```
info depth 1 cp 56 time 30 Move: 'g1f3'
info depth 2 cp 0 time 32 Move: 'g1f3'
info depth 3 cp 50 time 34 Move: 'g1f3'
info depth 4 cp 0 time 37 Move: 'g1f3'
info depth 5 cp 12 time 114 Move: 'g1f3'
info depth 6 cp 0 time 167 Move: 'g1f3'
info depth 7 cp 30 time 1754 Move: 'g1f3'
bestmove g1f3
```

```
Score of ChessChallenge vs ChessChallengeDev: 931 - 632 - 437  [0.575] 2000
...      ChessChallenge playing White: 540 - 269 - 192  [0.635] 1001
...      ChessChallenge playing Black: 391 - 363 - 245  [0.514] 999
...      White vs Black: 903 - 660 - 437  [0.561] 2000
Elo difference: 52.3 +/- 13.6, LOS: 100.0 %, DrawRatio: 21.9 %
```

### 1.15
Reverse futility pruning

623 tokens (+30)

```
info depth 1 cp 56 time 30 Move: 'g1f3'
info depth 2 cp 0 time 32 Move: 'g1f3'
info depth 3 cp 50 time 35 Move: 'g1f3'
info depth 4 cp 0 time 38 Move: 'g1f3'
info depth 5 cp 12 time 114 Move: 'g1f3'
info depth 6 cp 0 time 165 Move: 'g1f3'
info depth 7 cp 30 time 1641 Move: 'g1f3'
```

```
Score of ChessChallenge vs ChessChallengeDev: 953 - 580 - 467  [0.593] 2000
...      ChessChallenge playing White: 551 - 246 - 203  [0.652] 1000
...      ChessChallenge playing Black: 402 - 334 - 264  [0.534] 1000
...      White vs Black: 885 - 648 - 467  [0.559] 2000
Elo difference: 65.6 +/- 13.5, LOS: 100.0 %, DrawRatio: 23.4 %
```

### 1.16
Non-capture move score history table

679 tokens (+56)

```
info depth 1 cp 56 time 30 Move: 'g1f3'
info depth 2 cp 0 time 31 Move: 'g1f3'
info depth 3 cp 50 time 31 Move: 'g1f3'
info depth 4 cp 0 time 34 Move: 'g1f3'
info depth 5 cp 12 time 39 Move: 'g1f3'
info depth 6 cp 0 time 78 Move: 'g1f3'
info depth 7 cp 30 time 210 Move: 'g1f3'
info depth 8 cp 0 time 1389 Move: 'g1f3'
bestmove g1f3
```

```
Score of ChessChallenge vs ChessChallengeDev: 994 - 559 - 447  [0.609] 2000
...      ChessChallenge playing White: 553 - 245 - 203  [0.654] 1001
...      ChessChallenge playing Black: 441 - 314 - 244  [0.564] 999
...      White vs Black: 867 - 686 - 447  [0.545] 2000
Elo difference: 76.8 +/- 13.6, LOS: 100.0 %, DrawRatio: 22.4 %
```

### 1.17
Full transposition table and transposition table cutoffs

738 tokens (+59)

```
info depth 1 cp 56 time 30 Move: 'g1f3'
info depth 2 cp 0 time 31 Move: 'g1f3'
info depth 3 cp 50 time 32 Move: 'g1f3'
info depth 4 cp 0 time 34 Move: 'g1f3'
info depth 5 cp 12 time 41 Move: 'g1f3'
info depth 6 cp 0 time 66 Move: 'g1f3'
info depth 7 cp 30 time 137 Move: 'g1f3'
info depth 8 cp 0 time 720 Move: 'g1f3'
bestmove g1f3
```

```
Score of ChessChallenge vs ChessChallengeDev: 954 - 584 - 462  [0.593] 2000
...      ChessChallenge playing White: 544 - 227 - 230  [0.658] 1001
...      ChessChallenge playing Black: 410 - 357 - 232  [0.527] 999
...      White vs Black: 901 - 637 - 462  [0.566] 2000
Elo difference: 65.0 +/- 13.5, LOS: 100.0 %, DrawRatio: 23.1 %
```

### 1.17.1
Reduce token count

699 tokens (-39)

### 1.18
Null-move pruning

757 tokens (+58)

```
info depth 1 cp 56 time 30 Move: 'g1f3'
info depth 2 cp 0 time 31 Move: 'g1f3'
info depth 3 cp 50 time 32 Move: 'g1f3'
info depth 4 cp 0 time 33 Move: 'g1f3'
info depth 5 cp 12 time 35 Move: 'g1f3'
info depth 6 cp 0 time 40 Move: 'g1f3'
info depth 7 cp 30 time 45 Move: 'g1f3'
info depth 8 cp 0 time 144 Move: 'g1f3'
info depth 9 cp 18 time 230 Move: 'g1f3'
info depth 10 cp 2 time 742 Move: 'g1f3'
bestmove g1f3
```

```
Score of ChessChallenge vs ChessChallengeDev: 973 - 554 - 473  [0.605] 2000
...      ChessChallenge playing White: 550 - 228 - 223  [0.661] 1001
...      ChessChallenge playing Black: 423 - 326 - 250  [0.549] 999
...      White vs Black: 876 - 651 - 473  [0.556] 2000
Elo difference: 73.9 +/- 13.5, LOS: 100.0 %, DrawRatio: 23.6 %
```

### 1.19
Principal variation search

799 tokens (+42)

```
info depth 1 cp 56 time 29 Move: 'g1f3'
info depth 2 cp 0 time 30 Move: 'g1f3'
info depth 3 cp 50 time 31 Move: 'g1f3'
info depth 4 cp 0 time 32 Move: 'g1f3'
info depth 5 cp 12 time 34 Move: 'g1f3'
info depth 6 cp 0 time 39 Move: 'g1f3'
info depth 7 cp 30 time 43 Move: 'g1f3'
info depth 8 cp 0 time 108 Move: 'g1f3'
info depth 9 cp 18 time 165 Move: 'g1f3'
info depth 10 cp 2 time 557 Move: 'g1f3'
info depth 11 cp 24 time 1943 Move: 'g1f3'
bestmove g1f3
```

```
Score of ChessChallenge vs ChessChallengeDev: 866 - 607 - 527  [0.565] 2000
...      ChessChallenge playing White: 521 - 228 - 252  [0.646] 1001
...      ChessChallenge playing Black: 345 - 379 - 275  [0.483] 999
...      White vs Black: 900 - 573 - 527  [0.582] 2000
Elo difference: 45.2 +/- 13.1, LOS: 100.0 %, DrawRatio: 26.4 %
```

### 1.20
Late move reductions

820 tokens (+21)

```
info depth 1 cp 56 time 30 Move: 'g1f3'
info depth 2 cp 0 time 31 Move: 'g1f3'
info depth 3 cp 50 time 31 Move: 'g1f3'
info depth 4 cp 0 time 33 Move: 'g1f3'
info depth 5 cp 12 time 34 Move: 'g1f3'
info depth 6 cp 0 time 37 Move: 'g1f3'
info depth 7 cp 10 time 43 Move: 'g1f3'
info depth 8 cp 30 time 51 Move: 'g1f3'
info depth 9 cp 0 time 107 Move: 'g1f3'
info depth 10 cp 16 time 197 Move: 'g1f3'
info depth 11 cp 32 time 421 Move: 'g1f3'
info depth 12 cp 6 time 1663 Move: 'b1c3'
bestmove b1c3
```

```
Score of ChessChallenge vs ChessChallengeDev: 822 - 626 - 552  [0.549] 2000
...      ChessChallenge playing White: 491 - 263 - 246  [0.614] 1000
...      ChessChallenge playing Black: 331 - 363 - 306  [0.484] 1000
...      White vs Black: 854 - 594 - 552  [0.565] 2000
Elo difference: 34.2 +/- 13.0, LOS: 100.0 %, DrawRatio: 27.6 %
```

### 1.21
No RFP and NMP in PV nodes

826 tokens (+6)

```
info depth 1 cp 56 time 30 Move: 'g1f3'
info depth 2 cp 0 time 31 Move: 'g1f3'
info depth 3 cp 50 time 31 Move: 'g1f3'
info depth 4 cp 0 time 33 Move: 'g1f3'
info depth 5 cp 12 time 35 Move: 'g1f3'
info depth 6 cp 0 time 38 Move: 'g1f3'
info depth 7 cp 10 time 45 Move: 'g1f3'
info depth 8 cp 30 time 55 Move: 'g1f3'
info depth 9 cp 4 time 111 Move: 'd2d4'
info depth 10 cp 18 time 219 Move: 'd2d4'
info depth 11 cp 18 time 648 Move: 'g1f3'
```

```
Score of ChessChallenge vs ChessChallengeDev: 3817 - 3601 - 2582  [0.511] 10000
...      ChessChallenge playing White: 2243 - 1461 - 1296  [0.578] 5000
...      ChessChallenge playing Black: 1574 - 2140 - 1286  [0.443] 5000
...      White vs Black: 4383 - 3035 - 2582  [0.567] 10000
Elo difference: 7.5 +/- 5.9, LOS: 99.4 %, DrawRatio: 25.8 %
```

### 1.22
Retune evaluation using https://github.com/GediminasMasaitis/texel-tuner

826 tokens (=)

```
info depth 1 cp 58 time 30 Move: 'b1c3'
info depth 2 cp 0 time 31 Move: 'b1c3'
info depth 3 cp 52 time 31 Move: 'b1c3'
info depth 4 cp 2 time 33 Move: 'a2a4'
info depth 5 cp 22 time 36 Move: 'g1f3'
info depth 6 cp 2 time 42 Move: 'g1f3'
info depth 7 cp 18 time 50 Move: 'g1f3'
info depth 8 cp 32 time 68 Move: 'g1f3'
info depth 9 cp 12 time 106 Move: 'g1f3'
info depth 10 cp 18 time 201 Move: 'g1f3'
info depth 11 cp 22 time 738 Move: 'g1f3'
bestmove g1f3
```

```
Score of ChessChallenge vs ChessChallengeDev: 2005 - 1818 - 1177  [0.519] 5000
...      ChessChallenge playing White: 1125 - 771 - 605  [0.571] 2501
...      ChessChallenge playing Black: 880 - 1047 - 572  [0.467] 2499
...      White vs Black: 2172 - 1651 - 1177  [0.552] 5000
Elo difference: 13.0 +/- 8.4, LOS: 99.9 %, DrawRatio: 23.5 %
```

### 1.23
Internal iterative reduction

834 tokens (+8)

```
info depth 1 cp 58 time 32 Move: 'b1c3'
info depth 2 cp 0 time 33 Move: 'b1c3'
info depth 3 cp 52 time 34 Move: 'b1c3'
info depth 4 cp 2 time 35 Move: 'a2a4'
info depth 5 cp 22 time 38 Move: 'g1f3'
info depth 6 cp 2 time 42 Move: 'g1f3'
info depth 7 cp 18 time 50 Move: 'g1f3'
info depth 8 cp 32 time 67 Move: 'g1f3'
info depth 9 cp 12 time 99 Move: 'g1f3'
info depth 10 cp 18 time 173 Move: 'b1c3'
info depth 11 cp 14 time 309 Move: 'b1c3'
info depth 12 cp 22 time 618 Move: 'e2e4'
info depth 13 cp 18 time 1696 Move: 'e2e4'
bestmove e2e4
```

```
Score of ChessChallenge vs ChessChallengeDev: 1559 - 1363 - 1078  [0.524] 4000
...      ChessChallenge playing White: 925 - 557 - 518  [0.592] 2000
...      ChessChallenge playing Black: 634 - 806 - 560  [0.457] 2000
...      White vs Black: 1731 - 1191 - 1078  [0.568] 4000
Elo difference: 17.0 +/- 9.2, LOS: 100.0 %, DrawRatio: 27.0 %

Score of ChessChallenge vs vice1.1: 1293 - 446 - 261  [0.712] 2000
...      ChessChallenge playing White: 722 - 169 - 110  [0.776] 1001
...      ChessChallenge playing Black: 571 - 277 - 151  [0.647] 999
...      White vs Black: 999 - 740 - 261  [0.565] 2000
Elo difference: 157.0 +/- 15.4, LOS: 100.0 %, DrawRatio: 13.1 %

Score of ChessChallengeDev vs Tier1Example: 500 - 0 - 0  [1.000] 500
...      ChessChallengeDev playing White: 249 - 0 - 0  [1.000] 249
...      ChessChallengeDev playing Black: 251 - 0 - 0  [1.000] 251
...      White vs Black: 249 - 251 - 0  [0.498] 500
Elo difference: inf +/- nan, LOS: 100.0 %, DrawRatio: 0.0 %

Score of ChessChallengeDev vs Tier2Example: 366 - 69 - 65  [0.797] 500
...      ChessChallengeDev playing White: 204 - 23 - 22  [0.863] 249
...      ChessChallengeDev playing Black: 162 - 46 - 43  [0.731] 251
...      White vs Black: 250 - 185 - 65  [0.565] 500
Elo difference: 237.6 +/- 34.0, LOS: 100.0 %, DrawRatio: 13.0 %
```

### 1.23.1
Reduce token count

821 tokens (-13)

### 1.24
Bishop pair evaluation

840 tokens (+19)

```
info depth 1 cp 58 time 31 Move: 'b1c3'
info depth 2 cp 0 time 32 Move: 'b1c3'
info depth 3 cp 52 time 33 Move: 'b1c3'
info depth 4 cp 0 time 34 Move: 'b1c3'
info depth 5 cp 20 time 35 Move: 'b1c3'
info depth 6 cp 6 time 39 Move: 'b1c3'
info depth 7 cp 14 time 47 Move: 'b1c3'
info depth 8 cp 38 time 65 Move: 'b1c3'
info depth 9 cp 0 time 99 Move: 'b1c3'
info depth 10 cp 18 time 153 Move: 'b1c3'
info depth 11 cp 12 time 317 Move: 'b1c3'
info depth 12 cp 28 time 901 Move: 'b1c3'
info depth 13 cp 18 time 1932 Move: 'b1c3'
bestmove b1c3
```

```
Score of ChessChallenge vs ChessChallengeDev: 11608 - 10878 - 7514  [0.512] 30000
...      ChessChallenge playing White: 6858 - 4381 - 3761  [0.583] 15000
...      ChessChallenge playing Black: 4750 - 6497 - 3753  [0.442] 15000
...      White vs Black: 13355 - 9131 - 7514  [0.570] 30000
Elo difference: 8.5 +/- 3.4, LOS: 100.0 %, DrawRatio: 25.0 %
```

### 1.25
Aspiration windows

878 tokens (+38)

```
info depth 1 cp 58 time 40 Move: 'b1c3'
info depth 2 cp 0 time 42 Move: 'b1c3'
info depth 3 cp 52 time 43 Move: 'b1c3'
info depth 4 cp 0 time 45 Move: 'g1f3'
info depth 5 cp 20 time 46 Move: 'g1f3'
info depth 6 cp 6 time 50 Move: 'b1c3'
info depth 7 cp 26 time 61 Move: 'b1c3'
info depth 8 cp 36 time 85 Move: 'b1c3'
info depth 9 cp 0 time 127 Move: 'b1c3'
info depth 10 cp 22 time 192 Move: 'b1c3'
info depth 11 cp 22 time 354 Move: 'b1c3'
info depth 12 cp 10 time 1017 Move: 'b1c3'
info depth 13 cp 10 time 1905 Move: 'b1c3'
bestmove b1c3
```

```
Score of ChessChallenge vs ChessChallengeDev: 1252 - 935 - 813  [0.553] 3000
...      ChessChallenge playing White: 750 - 351 - 400  [0.633] 1501
...      ChessChallenge playing Black: 502 - 584 - 413  [0.473] 1499
...      White vs Black: 1334 - 853 - 813  [0.580] 3000
Elo difference: 36.8 +/- 10.6, LOS: 100.0 %, DrawRatio: 27.1 %
```

### 1.26
Split time management

888 tokens (+10)

```
info depth 1 cp 58 time 30 Move: 'b1c3'
info depth 2 cp 0 time 32 Move: 'b1c3'
info depth 3 cp 52 time 33 Move: 'b1c3'
info depth 4 cp 0 time 34 Move: 'g1f3'
info depth 5 cp 20 time 35 Move: 'g1f3'
info depth 6 cp 6 time 38 Move: 'b1c3'
info depth 7 cp 26 time 47 Move: 'b1c3'
info depth 8 cp 36 time 63 Move: 'b1c3'
info depth 9 cp 0 time 95 Move: 'b1c3'
info depth 10 cp 22 time 153 Move: 'b1c3'
info depth 11 cp 22 time 275 Move: 'b1c3'
info depth 12 cp 10 time 873 Move: 'b1c3'
info depth 13 cp 10 time 1710 Move: 'b1c3'
```

```
Score of ChessChallenge vs ChessChallengeDev: 955 - 510 - 535  [0.611] 2000
...      ChessChallenge playing White: 570 - 189 - 241  [0.691] 1000
...      ChessChallenge playing Black: 385 - 321 - 294  [0.532] 1000
...      White vs Black: 891 - 574 - 535  [0.579] 2000
Elo difference: 78.6 +/- 13.2, LOS: 100.0 %, DrawRatio: 26.8 %

Score of ChessChallenge vs Tier2Example: 844 - 68 - 88  [0.888] 1000
...      ChessChallenge playing White: 440 - 25 - 35  [0.915] 500
...      ChessChallenge playing Black: 404 - 43 - 53  [0.861] 500
...      White vs Black: 483 - 429 - 88  [0.527] 1000
Elo difference: 359.7 +/- 30.3, LOS: 100.0 %, DrawRatio: 8.8 %
```

### 1.27
Triple PVS on LMR

903 tokens (+15)

```
info depth 1 cp 58 time 31 Move: 'b1c3'
info depth 2 cp 0 time 32 Move: 'b1c3'
info depth 3 cp 52 time 33 Move: 'b1c3'
info depth 4 cp 0 time 34 Move: 'g1f3'
info depth 5 cp 20 time 35 Move: 'g1f3'
info depth 6 cp 0 time 38 Move: 'g1f3'
info depth 7 cp 20 time 44 Move: 'g1f3'
info depth 8 cp 16 time 56 Move: 'g1f3'
info depth 9 cp 18 time 84 Move: 'g1f3'
info depth 10 cp 18 time 105 Move: 'g1f3'
info depth 11 cp 10 time 365 Move: 'g1f3'
info depth 12 cp 12 time 818 Move: 'g1f3'
info depth 13 cp 12 time 1399 Move: 'g1f3'
info depth 14 cp 8 time 2805 Move: 'g1f3'
```

```
Score of ChessChallenge vs ChessChallengeDev: 779 - 629 - 592  [0.537] 2000
...      ChessChallenge playing White: 473 - 230 - 297  [0.622] 1000
...      ChessChallenge playing Black: 306 - 399 - 295  [0.454] 1000
...      White vs Black: 872 - 536 - 592  [0.584] 2000
Elo difference: 26.1 +/- 12.8, LOS: 100.0 %, DrawRatio: 29.6 %
```

### 1.28
Killer move ordering

931 tokens (+28)

```
info depth 1 cp 58 time 31 Move: 'b1c3'
info depth 2 cp 0 time 32 Move: 'b1c3'
info depth 3 cp 52 time 34 Move: 'b1c3'
info depth 4 cp 0 time 36 Move: 'b1c3'
info depth 5 cp 20 time 37 Move: 'b1c3'
info depth 6 cp 0 time 39 Move: 'b1c3'
info depth 7 cp 20 time 46 Move: 'b1c3'
info depth 8 cp 16 time 60 Move: 'b1c3'
info depth 9 cp 18 time 87 Move: 'b1c3'
info depth 10 cp 14 time 136 Move: 'b1c3'
info depth 11 cp 20 time 318 Move: 'b1c3'
info depth 12 cp 12 time 716 Move: 'b1c3'
info depth 13 cp 16 time 1157 Move: 'b1c3'
info depth 14 cp 16 time 1792 Move: 'b1c3'
bestmove b1c3
```

```
Score of ChessChallenge vs ChessChallengeDev: 725 - 610 - 665  [0.529] 2000
...      ChessChallenge playing White: 421 - 230 - 350  [0.595] 1001
...      ChessChallenge playing Black: 304 - 380 - 315  [0.462] 999
...      White vs Black: 801 - 534 - 665  [0.567] 2000
Elo difference: 20.0 +/- 12.4, LOS: 99.9 %, DrawRatio: 33.3 %
```

### 1.29
Qsearch TT equality

935 tokens (+4)

```
info depth 1 cp 58 time 31 Move: 'b1c3'
info depth 2 cp 0 time 32 Move: 'b1c3'
info depth 3 cp 52 time 33 Move: 'b1c3'
info depth 4 cp 0 time 34 Move: 'b1c3'
info depth 5 cp 20 time 35 Move: 'b1c3'
info depth 6 cp 0 time 38 Move: 'b1c3'
info depth 7 cp 20 time 44 Move: 'b1c3'
info depth 8 cp 16 time 57 Move: 'b1c3'
info depth 9 cp 18 time 84 Move: 'b1c3'
info depth 10 cp 14 time 131 Move: 'b1c3'
info depth 11 cp 20 time 305 Move: 'b1c3'
info depth 12 cp 12 time 679 Move: 'b1c3'
info depth 13 cp 16 time 1088 Move: 'b1c3'
info depth 14 cp 16 time 1694 Move: 'b1c3'
bestmove b1c3
```

```
Score of ChessChallenge vs ChessChallengeDev: 4209 - 3870 - 3921  [0.514] 12000
...      ChessChallenge playing White: 2586 - 1496 - 1919  [0.591] 6001
...      ChessChallenge playing Black: 1623 - 2374 - 2002  [0.437] 5999
...      White vs Black: 4960 - 3119 - 3921  [0.577] 12000
Elo difference: 9.8 +/- 5.1, LOS: 100.0 %, DrawRatio: 32.7 %
```

### 1.30
LMR adjustment on move count

939 tokens (+4)

```
info depth 1 cp 58 time 31 Move: 'b1c3'
info depth 2 cp 0 time 32 Move: 'b1c3'
info depth 3 cp 52 time 33 Move: 'b1c3'
info depth 4 cp 0 time 35 Move: 'b1c3'
info depth 5 cp 20 time 36 Move: 'b1c3'
info depth 6 cp 0 time 38 Move: 'b1c3'
info depth 7 cp 20 time 43 Move: 'b1c3'
info depth 8 cp 16 time 53 Move: 'b1c3'
info depth 9 cp 20 time 75 Move: 'b1c3'
info depth 10 cp 8 time 173 Move: 'e2e3'
info depth 11 cp 24 time 278 Move: 'e2e3'
info depth 12 cp 8 time 542 Move: 'e2e3'
info depth 13 cp 8 time 845 Move: 'e2e3'
info depth 14 cp 12 time 1411 Move: 'e2e3'
info depth 15 cp 12 time 2955 Move: 'e2e3'
bestmove e2e3
```

```
Score of ChessChallenge vs ChessChallengeDev: 1455 - 1207 - 1338  [0.531] 4000
...      ChessChallenge playing White: 877 - 468 - 656  [0.602] 2001
...      ChessChallenge playing Black: 578 - 739 - 682  [0.460] 1999
...      White vs Black: 1616 - 1046 - 1338  [0.571] 4000
Elo difference: 21.6 +/- 8.8, LOS: 100.0 %, DrawRatio: 33.5 %
```

### 1.31
More LMR reduction in zero-window nodes

950 (+11)

```
info depth 1 cp 58 time 30 Move: 'b1c3'
info depth 2 cp 0 time 31 Move: 'b1c3'
info depth 3 cp 52 time 32 Move: 'b1c3'
info depth 4 cp 0 time 33 Move: 'b1c3'
info depth 5 cp 20 time 34 Move: 'b1c3'
info depth 6 cp 0 time 36 Move: 'b1c3'
info depth 7 cp 20 time 38 Move: 'b1c3'
info depth 8 cp 0 time 54 Move: 'g1f3'
info depth 9 cp 22 time 73 Move: 'g1f3'
info depth 10 cp 12 time 117 Move: 'g1f3'
info depth 11 cp 18 time 174 Move: 'b1c3'
info depth 12 cp 14 time 317 Move: 'b1c3'
info depth 13 cp 8 time 1022 Move: 'b1c3'
info depth 14 cp 6 time 1687 Move: 'b1c3'
bestmove b1c3
```

```
Score of ChessChallenge vs ChessChallengeDev: 2054 - 1853 - 2093  [0.517] 6000
...      ChessChallenge playing White: 1271 - 711 - 1019  [0.593] 3001
...      ChessChallenge playing Black: 783 - 1142 - 1074  [0.440] 2999
...      White vs Black: 2413 - 1494 - 2093  [0.577] 6000
Elo difference: 11.6 +/- 7.1, LOS: 99.9 %, DrawRatio: 34.9 %

Score of ChessChallenge vs ChessChallengeTier2: 1756 - 94 - 150  [0.915] 2000
...      ChessChallenge playing White: 907 - 33 - 60  [0.937] 1000
...      ChessChallenge playing Black: 849 - 61 - 90  [0.894] 1000
...      White vs Black: 968 - 882 - 150  [0.521] 2000
Elo difference: 413.9 +/- 23.9, LOS: 100.0 %, DrawRatio: 7.5 %

Score of ChessChallenge vs kimbo1.0: 494 - 1112 - 394  [0.345] 2000
...      ChessChallenge playing White: 327 - 493 - 180  [0.417] 1000
...      ChessChallenge playing Black: 167 - 619 - 214  [0.274] 1000
...      White vs Black: 946 - 660 - 394  [0.572] 2000
Elo difference: -111.0 +/- 14.1, LOS: 0.0 %, DrawRatio: 19.7 %
```

### 1.32
TT after pruning

950 tokens (=)

```
info depth 1 cp 58 time 31 Move: 'b1c3'
info depth 2 cp 0 time 33 Move: 'b1c3'
info depth 3 cp 52 time 33 Move: 'b1c3'
info depth 4 cp 0 time 34 Move: 'b1c3'
info depth 5 cp 20 time 35 Move: 'b1c3'
info depth 6 cp 0 time 37 Move: 'b1c3'
info depth 7 cp 20 time 39 Move: 'b1c3'
info depth 8 cp 0 time 56 Move: 'g1f3'
info depth 9 cp 22 time 79 Move: 'g1f3'
info depth 10 cp 12 time 120 Move: 'g1f3'
info depth 11 cp 12 time 172 Move: 'g1f3'
info depth 12 cp 0 time 606 Move: 'g1f3'
info depth 13 cp 12 time 1061 Move: 'g1f3'
info depth 14 cp 8 time 1659 Move: 'g1f3'
bestmove g1f3
```

```
Score of ChessChallenge vs ChessChallengeDev: 2730 - 2450 - 2821  [0.517] 8001
...      ChessChallenge playing White: 1712 - 936 - 1353  [0.597] 4001
...      ChessChallenge playing Black: 1018 - 1514 - 1468  [0.438] 4000
...      White vs Black: 3226 - 1954 - 2821  [0.579] 8001
Elo difference: 12.2 +/- 6.1, LOS: 100.0 %, DrawRatio: 35.3 %

Score of ChessChallengeDev vs vice: 1640 - 169 - 191  [0.868] 2000
...      ChessChallengeDev playing White: 898 - 46 - 57  [0.926] 1001
...      ChessChallengeDev playing Black: 742 - 123 - 134  [0.810] 999
...      White vs Black: 1021 - 788 - 191  [0.558] 2000
Elo difference: 326.8 +/- 20.0, LOS: 100.0 %, DrawRatio: 9.6 %
```

### 1.33
Mobility evaluation

1000 tokens (+50)

```
info depth 1 cp 61 time 36 Move: 'b1c3'
info depth 2 cp 0 time 37 Move: 'b1c3'
info depth 3 cp 61 time 39 Move: 'b1c3'
info depth 4 cp 0 time 42 Move: 'b1c3'
info depth 5 cp 36 time 43 Move: 'b1c3'
info depth 6 cp 0 time 52 Move: 'b1c3'
info depth 7 cp 53 time 71 Move: 'b1c3'
info depth 8 cp 0 time 101 Move: 'b1c3'
info depth 9 cp 27 time 145 Move: 'g1f3'
info depth 10 cp 11 time 214 Move: 'g1f3'
info depth 11 cp 24 time 424 Move: 'd2d4'
info depth 12 cp 13 time 1023 Move: 'b1c3'
info depth 13 cp 14 time 1609 Move: 'b1c3'
bestmove b1c3
```

```
Score of ChessChallenge vs ChessChallengeDev: 1218 - 849 - 933  [0.561] 3000
...      ChessChallenge playing White: 755 - 313 - 432  [0.647] 1500
...      ChessChallenge playing Black: 463 - 536 - 501  [0.476] 1500
...      White vs Black: 1291 - 776 - 933  [0.586] 3000
Elo difference: 43.0 +/- 10.4, LOS: 100.0 %, DrawRatio: 31.1 %

Score of ChessChallenge vs ChessChallengeTier2: 1822 - 50 - 128  [0.943] 2000
...      ChessChallenge playing White: 940 - 17 - 44  [0.961] 1001
...      ChessChallenge playing Black: 882 - 33 - 84  [0.925] 999
...      White vs Black: 973 - 899 - 128  [0.518] 2000
Elo difference: 487.5 +/- 27.7, LOS: 100.0 %, DrawRatio: 6.4 %
```

### 1.33.1
Rebase on version 1.20 of base API

### 1.34
Persistent quiet move history with decay

1015 tokens (+15)

```
info depth 1 cp 61 time 33 Move: 'b1c3'
info depth 2 cp 0 time 34 Move: 'b1c3'
info depth 3 cp 61 time 34 Move: 'b1c3'
info depth 4 cp 0 time 37 Move: 'b1c3'
info depth 5 cp 36 time 38 Move: 'b1c3'
info depth 6 cp 0 time 46 Move: 'b1c3'
info depth 7 cp 53 time 64 Move: 'b1c3'
info depth 8 cp 0 time 93 Move: 'b1c3'
info depth 9 cp 27 time 137 Move: 'g1f3'
info depth 10 cp 11 time 202 Move: 'g1f3'
info depth 11 cp 24 time 399 Move: 'd2d4'
info depth 12 cp 13 time 983 Move: 'b1c3'
info depth 13 cp 14 time 1574 Move: 'b1c3'
bestmove b1c3
```

```
Score of ChessChallenge vs ChessChallengeDev: 1374 - 1142 - 1474  [0.529] 3990
...      ChessChallenge playing White: 825 - 446 - 725  [0.595] 1996
...      ChessChallenge playing Black: 549 - 696 - 749  [0.463] 1994
...      White vs Black: 1521 - 995 - 1474  [0.566] 3990
Elo difference: 20.2 +/- 8.6, LOS: 100.0 %, DrawRatio: 36.9 %
```

### 1.35
Keep upperbound TT move

Implemented by Goh CJ (cj5716)

1018 tokens (+3)

```
info depth 1 cp 61 time 33 Move: 'b1c3'
info depth 2 cp 0 time 34 Move: 'b1c3'
info depth 3 cp 61 time 34 Move: 'b1c3'
info depth 4 cp 0 time 36 Move: 'b1c3'
info depth 5 cp 36 time 38 Move: 'b1c3'
info depth 6 cp 0 time 44 Move: 'b1c3'
info depth 7 cp 53 time 60 Move: 'b1c3'
info depth 8 cp 0 time 96 Move: 'b1c3'
info depth 9 cp 27 time 117 Move: 'b1c3'
info depth 10 cp 11 time 194 Move: 'b1c3'
info depth 11 cp 11 time 402 Move: 'b1c3'
info depth 12 cp 8 time 951 Move: 'b1c3'
info depth 13 cp 14 time 1513 Move: 'b1c3'
bestmove b1c3
```

```
Score of ChessChallenge vs ChessChallengeDev: 6537 - 6175 - 7288  [0.509] 20000
...      ChessChallenge playing White: 4093 - 2282 - 3625  [0.591] 10000
...      ChessChallenge playing Black: 2444 - 3893 - 3663  [0.428] 10000
...      White vs Black: 7986 - 4726 - 7288  [0.582] 20000
Elo difference: 6.3 +/- 3.8, LOS: 99.9 %, DrawRatio: 36.4 %
```

### 1.35.1
Reduce token count

Implemented by Goh CJ (cj5716)

974 tokens (-44)

```
info depth 1 cp 61 time 33 Move: 'b1c3'
info depth 2 cp 0 time 34 Move: 'b1c3'
info depth 3 cp 61 time 34 Move: 'b1c3'
info depth 4 cp 0 time 36 Move: 'b1c3'
info depth 5 cp 36 time 38 Move: 'b1c3'
info depth 6 cp 0 time 44 Move: 'b1c3'
info depth 7 cp 53 time 60 Move: 'b1c3'
info depth 8 cp 0 time 95 Move: 'b1c3'
info depth 9 cp 27 time 117 Move: 'b1c3'
info depth 10 cp 11 time 191 Move: 'b1c3'
info depth 11 cp 11 time 407 Move: 'b1c3'
info depth 12 cp 8 time 940 Move: 'b1c3'
info depth 13 cp 14 time 1471 Move: 'b1c3'
info depth 14 cp 14 time 2928 Move: 'b1c3'
bestmove b1c3
```

### 1.35.2
Add node and nps output

974 tokens (=)

```
info depth 1 cp 61 time 32 nodes 5 nps 156 Move: 'b1c3'
info depth 2 cp 0 time 33 nodes 50 nps 1515 Move: 'b1c3'
info depth 3 cp 61 time 33 nodes 107 nps 3242 Move: 'b1c3'
info depth 4 cp 0 time 36 nodes 1028 nps 28555 Move: 'b1c3'
info depth 5 cp 36 time 37 nodes 1565 nps 42297 Move: 'b1c3'
info depth 6 cp 0 time 43 nodes 4517 nps 105046 Move: 'b1c3'
info depth 7 cp 53 time 58 nodes 11941 nps 205879 Move: 'b1c3'
info depth 8 cp 0 time 91 nodes 33138 nps 364153 Move: 'b1c3'
info depth 9 cp 27 time 111 nodes 45341 nps 408477 Move: 'b1c3'
info depth 10 cp 11 time 185 nodes 91680 nps 495567 Move: 'b1c3'
info depth 11 cp 11 time 382 nodes 216960 nps 567958 Move: 'b1c3'
info depth 12 cp 8 time 891 nodes 557909 nps 626160 Move: 'b1c3'
info depth 13 cp 14 time 1419 nodes 880064 nps 620200 Move: 'b1c3'
info depth 14 cp 14 time 2831 nodes 1763271 nps 622843 Move: 'b1c3'
bestmove b1c3
```
### 1.35.3
Reduce token count

Implemented by Goh CJ (cj5716)

960 tokens (-14)

```
info depth 1 cp 61 time 36 nodes 5 nps 138 Move: 'b1c3'
info depth 2 cp 0 time 37 nodes 50 nps 1351 Move: 'b1c3'
info depth 3 cp 61 time 38 nodes 107 nps 2815 Move: 'b1c3'
info depth 4 cp 0 time 40 nodes 1028 nps 25700 Move: 'b1c3'
info depth 5 cp 36 time 42 nodes 1565 nps 37261 Move: 'b1c3'
info depth 6 cp 0 time 49 nodes 4517 nps 92183 Move: 'b1c3'
info depth 7 cp 53 time 68 nodes 11941 nps 175602 Move: 'b1c3'
info depth 8 cp 0 time 105 nodes 33138 nps 315600 Move: 'b1c3'
info depth 9 cp 27 time 129 nodes 45341 nps 351480 Move: 'b1c3'
info depth 10 cp 11 time 215 nodes 91680 nps 426418 Move: 'b1c3'
info depth 11 cp 11 time 425 nodes 216960 nps 510494 Move: 'b1c3'
info depth 12 cp 8 time 947 nodes 557909 nps 589133 Move: 'b1c3'
info depth 13 cp 14 time 1463 nodes 880064 nps 601547 Move: 'b1c3'
info depth 14 cp 14 time 2896 nodes 1763271 nps 608864 Move: 'b1c3'
bestmove b1c3
```

### 1.36
King mobility

964 bytes (+4)

```
info depth 1 cp 61 time 33 nodes 5 nps 151 Move: 'b1c3'
info depth 2 cp 0 time 34 nodes 50 nps 1470 Move: 'b1c3'
info depth 3 cp 61 time 34 nodes 107 nps 3147 Move: 'b1c3'
info depth 4 cp 0 time 36 nodes 950 nps 26388 Move: 'b1c3'
info depth 5 cp 33 time 38 nodes 1408 nps 37052 Move: 'b1c3'
info depth 6 cp 0 time 43 nodes 3624 nps 84279 Move: 'b1c3'
info depth 7 cp 53 time 58 nodes 11000 nps 189655 Move: 'b1c3'
info depth 8 cp 0 time 91 nodes 31519 nps 346362 Move: 'b1c3'
info depth 9 cp 28 time 111 nodes 44096 nps 397261 Move: 'b1c3'
info depth 10 cp 12 time 163 nodes 79880 nps 490061 Move: 'b1c3'
info depth 11 cp 15 time 301 nodes 168162 nps 558677 Move: 'b1c3'
info depth 12 cp 8 time 610 nodes 371504 nps 609022 Move: 'b1c3'
info depth 13 cp 38 time 1895 nodes 1171177 nps 618035 Move: 'e2e4'
bestmove e2e4
```

```
Score of ChessChallenge vs ChessChallengeDev: 16461 - 15957 - 17582  [0.505] 50000
...      ChessChallenge playing White: 10320 - 6045 - 8635  [0.586] 25000
...      ChessChallenge playing Black: 6141 - 9912 - 8947  [0.425] 25000
...      White vs Black: 20232 - 12186 - 17582  [0.580] 50000
Elo difference: 3.5 +/- 2.4, LOS: 99.7 %, DrawRatio: 35.2 %
```

### 1.37
RFP margin 100

964 tokens (=)

```
info depth 1 cp 61 time 31 nodes 5 nps 161 Move: 'b1c3'
info depth 2 cp 0 time 32 nodes 50 nps 1562 Move: 'b1c3'
info depth 3 cp 61 time 32 nodes 107 nps 3343 Move: 'b1c3'
info depth 4 cp 0 time 34 nodes 950 nps 27941 Move: 'b1c3'
info depth 5 cp 33 time 35 nodes 1408 nps 40228 Move: 'b1c3'
info depth 6 cp 0 time 40 nodes 3602 nps 90050 Move: 'b1c3'
info depth 7 cp 53 time 55 nodes 10916 nps 198472 Move: 'b1c3'
info depth 8 cp 0 time 85 nodes 29159 nps 343047 Move: 'b1c3'
info depth 9 cp 28 time 106 nodes 41904 nps 395320 Move: 'b1c3'
info depth 10 cp 12 time 159 nodes 78138 nps 491433 Move: 'b1c3'
info depth 11 cp 15 time 287 nodes 163446 nps 569498 Move: 'b1c3'
info depth 12 cp 8 time 722 nodes 444652 nps 615861 Move: 'b1c3'
info depth 13 cp 10 time 1425 nodes 879272 nps 617032 Move: 'd2d4'
info depth 14 cp 11 time 2192 nodes 1359327 nps 620130 Move: 'd2d4'
bestmove d2d4
```

```
Score of ChessChallenge vs ChessChallengeDev: 13113 - 12486 - 14401  [0.508] 40000
...      ChessChallenge playing White: 8285 - 4630 - 7085  [0.591] 20000
...      ChessChallenge playing Black: 4828 - 7856 - 7316  [0.424] 20000
...      White vs Black: 16141 - 9458 - 14401  [0.584] 40000
Elo difference: 5.4 +/- 2.7, LOS: 100.0 %, DrawRatio: 36.0 %
```

### 1.38
King attack evaluation

1003 tokens (+39)

```
info depth 1 cp 59 time 34 nodes 5 nps 147 Move: 'b1c3'
info depth 2 cp 0 time 35 nodes 50 nps 1428 Move: 'b1c3'
info depth 3 cp 59 time 35 nodes 107 nps 3057 Move: 'b1c3'
info depth 4 cp 0 time 38 nodes 1017 nps 26763 Move: 'b1c3'
info depth 5 cp 31 time 39 nodes 1466 nps 37589 Move: 'b1c3'
info depth 6 cp 0 time 45 nodes 4400 nps 97777 Move: 'b1c3'
info depth 7 cp 47 time 53 nodes 8977 nps 169377 Move: 'b1c3'
info depth 8 cp 0 time 90 nodes 27407 nps 304522 Move: 'b1c3'
info depth 9 cp 18 time 115 nodes 40869 nps 355382 Move: 'b1c3'
info depth 10 cp 11 time 212 nodes 100586 nps 474462 Move: 'b1c3'
info depth 11 cp 29 time 373 nodes 193880 nps 519785 Move: 'b1c3'
info depth 12 cp 12 time 894 nodes 509180 nps 569552 Move: 'b1c3'
info depth 13 cp 24 time 1717 nodes 994340 nps 579114 Move: 'd2d4'
bestmove d2d4
```

```
Score of ChessChallenge vs ChessChallengeDev: 2726 - 2231 - 2543  [0.533] 7500
...      ChessChallenge playing White: 1639 - 856 - 1256  [0.604] 3751
...      ChessChallenge playing Black: 1087 - 1375 - 1287  [0.462] 3749
...      White vs Black: 3014 - 1943 - 2543  [0.571] 7500
Elo difference: 23.0 +/- 6.4, LOS: 100.0 %, DrawRatio: 33.9 %
```

### 1.38.1
Reduce token count

985 tokens (-18)

```
info depth 1 cp 59 time 32 nodes 5 nps 156 Move: 'b1c3'
info depth 2 cp 0 time 33 nodes 50 nps 1515 Move: 'b1c3'
info depth 3 cp 59 time 33 nodes 107 nps 3242 Move: 'b1c3'
info depth 4 cp 0 time 36 nodes 1017 nps 28250 Move: 'b1c3'
info depth 5 cp 31 time 37 nodes 1466 nps 39621 Move: 'b1c3'
info depth 6 cp 0 time 43 nodes 4400 nps 102325 Move: 'b1c3'
info depth 7 cp 47 time 52 nodes 8977 nps 172634 Move: 'b1c3'
info depth 8 cp 0 time 88 nodes 27407 nps 311443 Move: 'b1c3'
info depth 9 cp 18 time 111 nodes 40869 nps 368189 Move: 'b1c3'
info depth 10 cp 11 time 208 nodes 100586 nps 483586 Move: 'b1c3'
info depth 11 cp 29 time 373 nodes 193880 nps 519785 Move: 'b1c3'
info depth 12 cp 12 time 903 nodes 509180 nps 563875 Move: 'b1c3'
info depth 13 cp 24 time 1733 nodes 994340 nps 573768 Move: 'd2d4'
bestmove d2d4
```

```
Score of ChessChallenge vs ChessChallengeTier2: 2771 - 62 - 167  [0.952] 3000
...      ChessChallenge playing White: 1427 - 17 - 57  [0.970] 1501
...      ChessChallenge playing Black: 1344 - 45 - 110  [0.933] 1499
...      White vs Black: 1472 - 1361 - 167  [0.518] 3000
Elo difference: 517.1 +/- 24.3, LOS: 100.0 %, DrawRatio: 5.6 %

Score of ChessChallenge vs kimbo1.0: 785 - 805 - 410  [0.495] 2000
...      ChessChallenge playing White: 487 - 332 - 182  [0.577] 1001
...      ChessChallenge playing Black: 298 - 473 - 228  [0.412] 999
...      White vs Black: 960 - 630 - 410  [0.583] 2000
Elo difference: -3.5 +/- 13.6, LOS: 30.8 %, DrawRatio: 20.5 %
```

### 1.38.2
Reduce token count. Also improve UCI output to use the correct PV format.

Implemented by Goh CJ (cj5716)

962 tokens (-23)

```
info depth 1 cp 59 time 33 nodes 5 nps 151 pv b1c3
info depth 2 cp 0 time 33 nodes 50 nps 1515 pv b1c3
info depth 3 cp 59 time 33 nodes 107 nps 3242 pv b1c3
info depth 4 cp 0 time 36 nodes 1017 nps 28250 pv b1c3
info depth 5 cp 31 time 38 nodes 1466 nps 38578 pv b1c3
info depth 6 cp 0 time 44 nodes 4400 nps 100000 pv b1c3
info depth 7 cp 47 time 53 nodes 8977 nps 169377 pv b1c3
info depth 8 cp 0 time 89 nodes 27407 nps 307943 pv b1c3
info depth 9 cp 18 time 111 nodes 40869 nps 368189 pv b1c3
info depth 10 cp 11 time 210 nodes 100586 nps 478980 pv b1c3
info depth 11 cp 29 time 365 nodes 193880 nps 531178 pv b1c3
info depth 12 cp 12 time 885 nodes 509180 nps 575344 pv b1c3
info depth 13 cp 24 time 1696 nodes 994340 nps 586285 pv d2d4
bestmove d2d4
```

40+0.4:
```
Score of ChessChallengeDev vs kimbo1.0: 2086 - 1784 - 1130  [0.530] 5000
...      ChessChallengeDev playing White: 1249 - 674 - 578  [0.615] 2501
...      ChessChallengeDev playing Black: 837 - 1110 - 552  [0.445] 2499
...      White vs Black: 2359 - 1511 - 1130  [0.585] 5000
Elo difference: 21.0 +/- 8.5, LOS: 100.0 %, DrawRatio: 22.6 %
```

### 1.38.3
Reduce token count. Also improve UCI output so that CLI or GUI can track eval.

Implemented by Goh CJ (cj5716)

948 tokens (-14)

```
info depth 1 score cp 59 time 33 nodes 5 nps 151 pv b1c3
info depth 2 score cp 0 time 34 nodes 50 nps 1470 pv b1c3
info depth 3 score cp 59 time 34 nodes 107 nps 3147 pv b1c3
info depth 4 score cp 0 time 37 nodes 1017 nps 27486 pv b1c3
info depth 5 score cp 31 time 38 nodes 1466 nps 38578 pv b1c3
info depth 6 score cp 0 time 44 nodes 4400 nps 100000 pv b1c3
info depth 7 score cp 47 time 53 nodes 8977 nps 169377 pv b1c3
info depth 8 score cp 0 time 89 nodes 27407 nps 307943 pv b1c3
info depth 9 score cp 18 time 113 nodes 40869 nps 361672 pv b1c3
info depth 10 score cp 11 time 207 nodes 100586 nps 485922 pv b1c3
info depth 11 score cp 29 time 358 nodes 193880 nps 541564 pv b1c3
info depth 12 score cp 12 time 881 nodes 509180 nps 577956 pv b1c3
info depth 13 score cp 24 time 1715 nodes 994340 nps 579790 pv d2d4
bestmove d2d4
```

### 1.39
Late move pruning

980 tokens (+32)

```
info depth 1 score cp 59 time 34 nodes 5 nps 147 pv b1c3
info depth 2 score cp 0 time 35 nodes 50 nps 1428 pv b1c3
info depth 3 score cp 59 time 36 nodes 107 nps 2972 pv b1c3
info depth 4 score cp 0 time 37 nodes 749 nps 20243 pv b1c3
info depth 5 score cp 31 time 38 nodes 1111 nps 29236 pv b1c3
info depth 6 score cp 0 time 43 nodes 3095 nps 71976 pv b1c3
info depth 7 score cp 45 time 48 nodes 5203 nps 108395 pv b1c3
info depth 8 score cp 4 time 73 nodes 18050 nps 247260 pv b1c3
info depth 9 score cp 20 time 88 nodes 26045 nps 295965 pv b1c3
info depth 10 score cp 10 time 133 nodes 53397 nps 401481 pv b1c3
info depth 11 score cp 11 time 247 nodes 124747 nps 505048 pv d2d4
info depth 12 score cp 20 time 470 nodes 265324 nps 564519 pv g1f3
info depth 13 score cp 20 time 732 nodes 422640 nps 577377 pv g1f3
info depth 14 score cp 22 time 1538 nodes 907386 nps 589977 pv b1c3
bestmove b1c3
```

```
Score of ChessChallenge vs ChessChallengeDev: 6896 - 6034 - 7070  [0.522] 20000
...      ChessChallenge playing White: 4317 - 2208 - 3475  [0.605] 10000
...      ChessChallenge playing Black: 2579 - 3826 - 3595  [0.438] 10000
...      White vs Black: 8143 - 4787 - 7070  [0.584] 20000
Elo difference: 15.0 +/- 3.9, LOS: 100.0 %, DrawRatio: 35.4 %
```

### 1.40
Smaller late move pruning

976 tokens (-4)

```
info depth 1 score cp 59 time 45 nodes 5 nps 111 pv b1c3
info depth 2 score cp 0 time 46 nodes 50 nps 1086 pv b1c3
info depth 3 score cp 59 time 46 nodes 107 nps 2326 pv b1c3
info depth 4 score cp 0 time 49 nodes 749 nps 15285 pv b1c3
info depth 5 score cp 31 time 50 nodes 1111 nps 22220 pv b1c3
info depth 6 score cp 0 time 54 nodes 3095 nps 57314 pv b1c3
info depth 7 score cp 45 time 59 nodes 5203 nps 88186 pv b1c3
info depth 8 score cp 0 time 88 nodes 19366 nps 220068 pv b1c3
info depth 9 score cp 18 time 102 nodes 25726 nps 252215 pv b1c3
info depth 10 score cp 11 time 135 nodes 45796 nps 339229 pv b1c3
info depth 11 score cp 20 time 226 nodes 100876 nps 446353 pv d2d4
info depth 12 score cp 23 time 380 nodes 198401 nps 522107 pv d2d4
info depth 13 score cp 27 time 680 nodes 377859 nps 555675 pv d2d4
info depth 14 score cp 19 time 1705 nodes 981153 nps 575456 pv e2e4
bestmove e2e4
```

```
Score of ChessChallenge vs ChessChallengeDev: 1314 - 1264 - 1422  [0.506] 4000
...      ChessChallenge playing White: 816 - 490 - 695  [0.581] 2001
...      ChessChallenge playing Black: 498 - 774 - 727  [0.431] 1999
...      White vs Black: 1590 - 988 - 1422  [0.575] 4000
Elo difference: 4.3 +/- 8.6, LOS: 83.8 %, DrawRatio: 35.5 %
```

### 1.41

Open file evaluation, doubled pawn evaluation

1007 tokens (+31)

```
info depth 1 score cp 57 time 33 nodes 5 nps 151 pv b1c3
info depth 2 score cp 0 time 34 nodes 50 nps 1470 pv b1c3
info depth 3 score cp 57 time 34 nodes 107 nps 3147 pv b1c3
info depth 4 score cp 0 time 36 nodes 751 nps 20861 pv b1c3
info depth 5 score cp 32 time 36 nodes 1113 nps 30916 pv b1c3
info depth 6 score cp 0 time 41 nodes 3121 nps 76121 pv b1c3
info depth 7 score cp 43 time 45 nodes 5196 nps 115466 pv b1c3
info depth 8 score cp 2 time 73 nodes 19698 nps 269835 pv b1c3
info depth 9 score cp 18 time 89 nodes 27725 nps 311516 pv b1c3
info depth 10 score cp 0 time 148 nodes 66889 nps 451952 pv b1c3
info depth 11 score cp 10 time 255 nodes 134379 nps 526976 pv d2d4
info depth 12 score cp 14 time 497 nodes 286860 nps 577183 pv b1c3
info depth 13 score cp 14 time 778 nodes 452943 nps 582188 pv b1c3
info depth 14 score cp 14 time 1213 nodes 717938 nps 591869 pv b1c3
info depth 15 score cp 20 time 2697 nodes 1582946 nps 586928 pv b1c3
bestmove b1c3
```

```
Score of ChessChallenge vs ChessChallengeDev: 2192 - 1816 - 1992  [0.531] 6000
...      ChessChallenge playing White: 1298 - 707 - 994  [0.599] 2999
...      ChessChallenge playing Black: 894 - 1109 - 998  [0.464] 3001
...      White vs Black: 2407 - 1601 - 1992  [0.567] 6000
Elo difference: 21.8 +/- 7.2, LOS: 100.0 %, DrawRatio: 33.2 %

Score of ChessChallenge vs ChessChallenge1.34: 3953 - 2410 - 2637  [0.586] 9000
...      ChessChallenge playing White: 2335 - 892 - 1273  [0.660] 4500
...      ChessChallenge playing Black: 1618 - 1518 - 1364  [0.511] 4500
...      White vs Black: 3853 - 2510 - 2637  [0.575] 9000
Elo difference: 60.2 +/- 6.1, LOS: 100.0 %, DrawRatio: 29.3 %

Score of ChessChallenge vs ChessChallengeTier2: 11188 - 226 - 586  [0.957] 12000
...      ChessChallenge playing White: 5746 - 61 - 194  [0.974] 6001
...      ChessChallenge playing Black: 5442 - 165 - 392  [0.940] 5999
...      White vs Black: 5911 - 5503 - 586  [0.517] 12000
Elo difference: 537.9 +/- 12.8, LOS: 100.0 %, DrawRatio: 4.9 %
```

### 1.41.1
Reduce token count. Also correct definition of node.

Implemented by Goh CJ (cj5716)

991 tokens (-16)

```
info depth 1 score cp 57 time 31 nodes 22 nps 709 pv b1c3
info depth 2 score cp 0 time 32 nodes 103 nps 3218 pv b1c3
info depth 3 score cp 57 time 32 nodes 237 nps 7406 pv b1c3
info depth 4 score cp 0 time 34 nodes 1083 nps 31852 pv b1c3
info depth 5 score cp 32 time 35 nodes 1666 nps 47600 pv b1c3
info depth 6 score cp 0 time 39 nodes 4515 nps 115769 pv b1c3
info depth 7 score cp 43 time 44 nodes 7521 nps 170931 pv b1c3
info depth 8 score cp 2 time 71 nodes 30300 nps 426760 pv b1c3
info depth 9 score cp 18 time 86 nodes 43734 nps 508534 pv b1c3
info depth 10 score cp 0 time 148 nodes 107473 nps 726168 pv b1c3
info depth 11 score cp 10 time 254 nodes 226898 nps 893299 pv d2d4
info depth 12 score cp 14 time 501 nodes 500741 nps 999483 pv b1c3
info depth 13 score cp 14 time 790 nodes 823444 nps 1042334 pv b1c3
info depth 14 score cp 14 time 1233 nodes 1329412 nps 1078193 pv b1c3
info depth 15 score cp 20 time 2767 nodes 3086019 nps 1115294 pv b1c3
bestmove b1c3
```

### 1.42
LMR adjustment by depth

995 tokens (+4)

```
info depth 1 score cp 57 time 34 nodes 22 nps 647 pv b1c3
info depth 2 score cp 0 time 35 nodes 103 nps 2942 pv b1c3
info depth 3 score cp 57 time 35 nodes 237 nps 6771 pv b1c3
info depth 4 score cp 0 time 37 nodes 1083 nps 29270 pv b1c3
info depth 5 score cp 32 time 39 nodes 1666 nps 42717 pv b1c3
info depth 6 score cp 0 time 44 nodes 4515 nps 102613 pv b1c3
info depth 7 score cp 43 time 48 nodes 7521 nps 156687 pv b1c3
info depth 8 score cp 2 time 70 nodes 23771 nps 339585 pv b1c3
info depth 9 score cp 18 time 80 nodes 33092 nps 413650 pv b1c3
info depth 10 score cp 0 time 111 nodes 61175 nps 551126 pv b1c3
info depth 11 score cp 18 time 172 nodes 125070 nps 727151 pv g1f3
info depth 12 score cp 18 time 219 nodes 175895 nps 803173 pv g1f3
info depth 13 score cp 6 time 686 nodes 686494 nps 1000720 pv g1f3
info depth 14 score cp 6 time 1025 nodes 1055693 nps 1029944 pv g1f3
info depth 15 score cp 11 time 2111 nodes 2273197 nps 1076834 pv b1c3
bestmove b1c3
```

```
Score of ChessChallenge vs ChessChallengeDev: 17359 - 16785 - 20856  [0.505] 55000
...      ChessChallenge playing White: 11002 - 6088 - 10411  [0.589] 27501
...      ChessChallenge playing Black: 6357 - 10697 - 10445  [0.421] 27499
...      White vs Black: 21699 - 12445 - 20856  [0.584] 55000
Elo difference: 3.6 +/- 2.3, LOS: 99.9 %, DrawRatio: 37.9 %
```

### 1.43
NMP adjustment by depth

999 tokens (+4)

```
info depth 1 score cp 57 time 33 nodes 22 nps 666 pv b1c3
info depth 2 score cp 0 time 33 nodes 103 nps 3121 pv b1c3
info depth 3 score cp 57 time 34 nodes 237 nps 6970 pv b1c3
info depth 4 score cp 0 time 36 nodes 1083 nps 30083 pv b1c3
info depth 5 score cp 32 time 37 nodes 1666 nps 45027 pv b1c3
info depth 6 score cp 0 time 42 nodes 4515 nps 107500 pv b1c3
info depth 7 score cp 43 time 47 nodes 7734 nps 164553 pv b1c3
info depth 8 score cp 2 time 67 nodes 21769 nps 324910 pv b1c3
info depth 9 score cp 18 time 79 nodes 33714 nps 426759 pv b1c3
info depth 10 score cp 0 time 117 nodes 64795 nps 553803 pv b1c3
info depth 11 score cp 24 time 255 nodes 184284 nps 722682 pv b1c3
info depth 12 score cp 30 time 360 nodes 286374 nps 795483 pv b1c3
info depth 13 score cp 30 time 425 nodes 357542 nps 841275 pv b1c3
info depth 14 score cp 12 time 1082 nodes 1070964 nps 989800 pv b1c3
info depth 15 score cp 12 time 1450 nodes 1480979 nps 1021364 pv b1c3
info depth 16 score cp 14 time 1767 nodes 1840374 nps 1041524 pv b1c3
bestmove b1c3
```

```
Score of ChessChallenge vs ChessChallengeDev: 6415 - 6062 - 8123  [0.509] 20600
...      ChessChallenge playing White: 4027 - 2239 - 4034  [0.587] 10300
...      ChessChallenge playing Black: 2388 - 3823 - 4089  [0.430] 10300
...      White vs Black: 7850 - 4627 - 8123  [0.578] 20600
Elo difference: 6.0 +/- 3.7, LOS: 99.9 %, DrawRatio: 39.4 %
```

### 1.43.1
Reduce token count

Implemented by Goh CJ (cj5716)

974 tokens (-25)

```
info depth 1 score cp 57 time 33 nodes 22 nps 666 pv b1c3
info depth 2 score cp 0 time 34 nodes 103 nps 3029 pv b1c3
info depth 3 score cp 57 time 34 nodes 237 nps 6970 pv b1c3
info depth 4 score cp 0 time 36 nodes 1083 nps 30083 pv b1c3
info depth 5 score cp 32 time 37 nodes 1666 nps 45027 pv b1c3
info depth 6 score cp 0 time 42 nodes 4515 nps 107500 pv b1c3
info depth 7 score cp 43 time 46 nodes 7734 nps 168130 pv b1c3
info depth 8 score cp 2 time 67 nodes 21769 nps 324910 pv b1c3
info depth 9 score cp 18 time 80 nodes 33714 nps 421425 pv b1c3
info depth 10 score cp 0 time 115 nodes 64795 nps 563434 pv b1c3
info depth 11 score cp 24 time 232 nodes 184284 nps 794327 pv b1c3
info depth 12 score cp 30 time 329 nodes 286374 nps 870437 pv b1c3
info depth 13 score cp 30 time 397 nodes 357542 nps 900609 pv b1c3
info depth 14 score cp 12 time 1064 nodes 1070964 nps 1006545 pv b1c3
info depth 15 score cp 12 time 1450 nodes 1480979 nps 1021364 pv b1c3
info depth 16 score cp 14 time 1784 nodes 1840374 nps 1031599 pv b1c3
bestmove b1c3
```

### 1.44
Tempo evaluation

974 tokens (=)

```
info depth 1 score cp 42 time 37 nodes 22 nps 594 pv b1c3
info depth 2 score cp 15 time 38 nodes 82 nps 2157 pv b1c3
info depth 3 score cp 42 time 39 nodes 200 nps 5128 pv b1c3
info depth 4 score cp 15 time 40 nodes 598 nps 14950 pv b1c3
info depth 5 score cp 17 time 42 nodes 1411 nps 33595 pv b1c3
info depth 6 score cp 15 time 47 nodes 3101 nps 65978 pv b1c3
info depth 7 score cp 28 time 50 nodes 5802 nps 116040 pv b1c3
info depth 8 score cp 15 time 60 nodes 12012 nps 200200 pv b1c3
info depth 9 score cp 3 time 82 nodes 28596 nps 348731 pv b1c3
info depth 10 score cp 20 time 133 nodes 74480 nps 560000 pv b1c3
info depth 11 score cp 12 time 188 nodes 130481 nps 694047 pv b1c3
info depth 12 score cp 26 time 273 nodes 219024 nps 802285 pv b1c3
info depth 13 score cp 21 time 663 nodes 626848 nps 945472 pv e2e4
info depth 14 score cp 27 time 921 nodes 887775 nps 963925 pv e2e4
info depth 15 score cp 20 time 1994 nodes 2031158 nps 1018634 pv e2e4
bestmove e2e4
```

```
Score of ChessChallenge vs ChessChallengeDev: 9845 - 9410 - 12745  [0.507] 32000
...      ChessChallenge playing White: 6278 - 3360 - 6363  [0.591] 16001
...      ChessChallenge playing Black: 3567 - 6050 - 6382  [0.422] 15999
...      White vs Black: 12328 - 6927 - 12745  [0.584] 32000
Elo difference: 4.7 +/- 2.9, LOS: 99.9 %, DrawRatio: 39.8 %
```

### 1.44.1
Reduce token count via an approach inspired by Tyrant7 in his submission here: https://github.com/Tyrant7/Chess-Challenge

Implemented by Goh CJ (cj5716)

953 tokens (-21)

```
info depth 1 score cp 42 time 38 nodes 22 nps 578 pv b1c3
info depth 2 score cp 15 time 39 nodes 82 nps 2102 pv b1c3
info depth 3 score cp 42 time 39 nodes 200 nps 5128 pv b1c3
info depth 4 score cp 15 time 40 nodes 598 nps 14950 pv b1c3
info depth 5 score cp 17 time 41 nodes 1411 nps 34414 pv b1c3
info depth 6 score cp 15 time 44 nodes 3101 nps 70477 pv b1c3
info depth 7 score cp 28 time 49 nodes 5802 nps 118408 pv b1c3
info depth 8 score cp 15 time 58 nodes 12012 nps 207103 pv b1c3
info depth 9 score cp 3 time 83 nodes 28596 nps 344530 pv b1c3
info depth 10 score cp 20 time 139 nodes 74480 nps 535827 pv b1c3
info depth 11 score cp 12 time 196 nodes 130481 nps 665719 pv b1c3
info depth 12 score cp 26 time 283 nodes 219024 nps 773936 pv b1c3
info depth 13 score cp 21 time 680 nodes 626848 nps 921835 pv e2e4
info depth 14 score cp 27 time 926 nodes 887775 nps 958720 pv e2e4
info depth 15 score cp 20 time 1984 nodes 2031158 nps 1023769 pv e2e4
bestmove e2e4
```

### 1.45
Reverse futility pruning up to depth 7

953 tokens (=)

```
info depth 1 score cp 42 time 34 nodes 22 nps 647 pv b1c3
info depth 2 score cp 15 time 35 nodes 82 nps 2342 pv b1c3
info depth 3 score cp 42 time 35 nodes 200 nps 5714 pv b1c3
info depth 4 score cp 15 time 36 nodes 598 nps 16611 pv b1c3
info depth 5 score cp 17 time 37 nodes 1411 nps 38135 pv b1c3
info depth 6 score cp 15 time 40 nodes 3101 nps 77525 pv b1c3
info depth 7 score cp 28 time 43 nodes 5802 nps 134930 pv b1c3
info depth 8 score cp 15 time 51 nodes 12012 nps 235529 pv b1c3
info depth 9 score cp 3 time 72 nodes 28596 nps 397166 pv b1c3
info depth 10 score cp 20 time 122 nodes 74480 nps 610491 pv b1c3
info depth 11 score cp 12 time 175 nodes 130481 nps 745605 pv b1c3
info depth 12 score cp 26 time 264 nodes 218982 nps 829477 pv b1c3
info depth 13 score cp 21 time 650 nodes 623696 nps 959532 pv e2e4
info depth 14 score cp 27 time 893 nodes 883478 nps 989337 pv e2e4
info depth 15 score cp 17 time 2348 nodes 2479799 nps 1056132 pv b1c3
bestmove b1c3
```

```
Score of ChessChallenge vs ChessChallengeDev: 8150 - 7768 - 10582  [0.507] 26500
...      ChessChallenge playing White: 5159 - 2837 - 5255  [0.588] 13251
...      ChessChallenge playing Black: 2991 - 4931 - 5327  [0.427] 13249
...      White vs Black: 10090 - 5828 - 10582  [0.580] 26500
Elo difference: 5.0 +/- 3.2, LOS: 99.9 %, DrawRatio: 39.9 %
```

### 1.46
Reverse futility pruning margin 75

953 tokens (=)

```
info depth 1 score cp 42 time 34 nodes 22 nps 647 pv b1c3
info depth 2 score cp 15 time 34 nodes 82 nps 2411 pv b1c3
info depth 3 score cp 42 time 35 nodes 200 nps 5714 pv b1c3
info depth 4 score cp 15 time 36 nodes 592 nps 16444 pv b1c3
info depth 5 score cp 17 time 37 nodes 1373 nps 37108 pv b1c3
info depth 6 score cp 15 time 39 nodes 3032 nps 77743 pv b1c3
info depth 7 score cp 28 time 43 nodes 5626 nps 130837 pv b1c3
info depth 8 score cp 15 time 51 nodes 11539 nps 226254 pv b1c3
info depth 9 score cp 3 time 72 nodes 27417 nps 380791 pv b1c3
info depth 10 score cp 20 time 100 nodes 52468 nps 524680 pv b1c3
info depth 11 score cp 18 time 145 nodes 99052 nps 683117 pv b1c3
info depth 12 score cp 25 time 249 nodes 204510 nps 821325 pv b1c3
info depth 13 score cp 32 time 791 nodes 774828 nps 979554 pv e2e4
info depth 14 score cp 32 time 1108 nodes 1111812 nps 1003440 pv e2e4
info depth 15 score cp 32 time 1351 nodes 1370773 nps 1014635 pv e2e4
info depth 16 score cp 14 time 4254 nodes 4449298 nps 1045909 pv e2e4
bestmove e2e4
```

```
Score of ChessChallenge vs ChessChallengeDev: 6161 - 5800 - 8039  [0.509] 20000
...      ChessChallenge playing White: 3975 - 2075 - 3949  [0.595] 9999
...      ChessChallenge playing Black: 2186 - 3725 - 4090  [0.423] 10001
...      White vs Black: 7700 - 4261 - 8039  [0.586] 20000
Elo difference: 6.3 +/- 3.7, LOS: 100.0 %, DrawRatio: 40.2 %
```

### 1.47
History malus

987 tokens (+34)

```
info depth 1 score cp 42 time 43 nodes 22 nps 511 pv b1c3
info depth 2 score cp 15 time 44 nodes 82 nps 1863 pv b1c3
info depth 3 score cp 42 time 44 nodes 194 nps 4409 pv b1c3
info depth 4 score cp 15 time 46 nodes 641 nps 13934 pv b1c3
info depth 5 score cp 17 time 47 nodes 1344 nps 28595 pv b1c3
info depth 6 score cp 15 time 51 nodes 3662 nps 71803 pv b1c3
info depth 7 score cp 28 time 57 nodes 7481 nps 131245 pv b1c3
info depth 8 score cp 15 time 72 nodes 14953 nps 207680 pv b1c3
info depth 9 score cp 18 time 91 nodes 28708 nps 315472 pv b1c3
info depth 10 score cp 26 time 135 nodes 60218 nps 446059 pv b1c3
info depth 11 score cp 18 time 198 nodes 117342 nps 592636 pv b1c3
info depth 12 score cp 22 time 360 nodes 276634 nps 768427 pv b1c3
info depth 13 score cp 21 time 617 nodes 524384 nps 849893 pv b1c3
info depth 14 score cp 24 time 1070 nodes 979201 nps 915141 pv b1c3
info depth 15 score cp 24 time 1431 nodes 1342691 nps 938288 pv b1c3
info depth 16 score cp 17 time 2225 nodes 2159928 nps 970754 pv b1c3
bestmove b1c3
```

```
Score of ChessChallenge vs ChessChallengeDev: 1778 - 1282 - 1940  [0.550] 5000
...      ChessChallenge playing White: 1140 - 459 - 901  [0.636] 2500
...      ChessChallenge playing Black: 638 - 823 - 1039  [0.463] 2500
...      White vs Black: 1963 - 1097 - 1940  [0.587] 5000
Elo difference: 34.6 +/- 7.5, LOS: 100.0 %, DrawRatio: 38.8 %

Score of ChessChallenge vs ChessChallenge1.34: 983 - 406 - 611  [0.644] 2000
...      ChessChallenge playing White: 587 - 141 - 272  [0.723] 1000
...      ChessChallenge playing Black: 396 - 265 - 339  [0.566] 1000
...      White vs Black: 852 - 537 - 611  [0.579] 2000
Elo difference: 103.2 +/- 13.0, LOS: 100.0 %, DrawRatio: 30.6 %
```

### 1.48
Less reduction if history is positive

1001 tokens (+14)

```
info depth 1 score cp 42 time 40 nodes 22 nps 550 pv b1c3
info depth 2 score cp 15 time 41 nodes 82 nps 2000 pv b1c3
info depth 3 score cp 42 time 41 nodes 194 nps 4731 pv b1c3
info depth 4 score cp 15 time 43 nodes 641 nps 14906 pv b1c3
info depth 5 score cp 17 time 44 nodes 1344 nps 30545 pv b1c3
info depth 6 score cp 15 time 48 nodes 3724 nps 77583 pv b1c3
info depth 7 score cp 28 time 53 nodes 7065 nps 133301 pv b1c3
info depth 8 score cp 15 time 63 nodes 13116 nps 208190 pv b1c3
info depth 9 score cp 20 time 88 nodes 26405 nps 300056 pv b1c3
info depth 10 score cp 20 time 121 nodes 50286 nps 415586 pv b1c3
info depth 11 score cp 20 time 243 nodes 151982 nps 625440 pv d2d4
info depth 12 score cp 25 time 382 nodes 278564 nps 729225 pv d2d4
info depth 13 score cp 21 time 817 nodes 662924 nps 811412 pv g1f3
info depth 14 score cp 21 time 1234 nodes 1042615 nps 844906 pv g1f3
info depth 15 score cp 17 time 2116 nodes 1910272 nps 902775 pv g1f3
bestmove g1f3
```

```
Score of ChessChallenge vs ChessChallengeDev: 1647 - 1371 - 1982  [0.528] 5000
...      ChessChallenge playing White: 1074 - 474 - 952  [0.620] 2500
...      ChessChallenge playing Black: 573 - 897 - 1030  [0.435] 2500
...      White vs Black: 1971 - 1047 - 1982  [0.592] 5000
Elo difference: 19.2 +/- 7.5, LOS: 100.0 %, DrawRatio: 39.6 %

Score of ChessChallenge vs ChessChallengeTier2: 1891 - 27 - 82  [0.966] 2000
...      ChessChallenge playing White: 970 - 7 - 23  [0.982] 1000
...      ChessChallenge playing Black: 921 - 20 - 59  [0.951] 1000
...      White vs Black: 990 - 928 - 82  [0.515] 2000
Elo difference: 581.4 +/- 35.2, LOS: 100.0 %, DrawRatio: 4.1 %

cx
```

### 1.49
More aggressive LMP

999 tokens (-2)

```
info depth 1 score cp 42 time 35 nodes 22 nps 628 pv b1c3
info depth 2 score cp 15 time 35 nodes 82 nps 2342 pv b1c3
info depth 3 score cp 42 time 36 nodes 190 nps 5277 pv b1c3
info depth 4 score cp 15 time 37 nodes 552 nps 14918 pv b1c3
info depth 5 score cp 17 time 38 nodes 1134 nps 29842 pv b1c3
info depth 6 score cp 15 time 40 nodes 2787 nps 69675 pv b1c3
info depth 7 score cp 28 time 47 nodes 6981 nps 148531 pv b1c3
info depth 8 score cp 15 time 54 nodes 12099 nps 224055 pv b1c3
info depth 9 score cp 14 time 91 nodes 35749 nps 392846 pv b1c3
info depth 10 score cp 20 time 123 nodes 65540 nps 532845 pv b1c3
info depth 11 score cp 30 time 186 nodes 116066 nps 624010 pv b1c3
info depth 12 score cp 30 time 286 nodes 208607 nps 731954 pv b1c3
info depth 13 score cp 13 time 646 nodes 552393 nps 855097 pv b1c3
info depth 14 score cp 36 time 1153 nodes 1000291 nps 867555 pv b1c3
info depth 15 score cp 36 time 1665 nodes 1493149 nps 896786 pv b1c3
bestmove b1c3
```

```
Score of ChessChallenge vs ChessChallengeDev: 9253 - 8814 - 11933  [0.507] 30000
...      ChessChallenge playing White: 5935 - 3132 - 5935  [0.593] 15002
...      ChessChallenge playing Black: 3318 - 5682 - 5998  [0.421] 14998
...      White vs Black: 11617 - 6450 - 11933  [0.586] 30000
Elo difference: 5.1 +/- 3.0, LOS: 99.9 %, DrawRatio: 39.8 %

Score of ChessChallengeDev vs ChessChallengeTier2: 1891 - 33 - 76  [0.965] 2000
...      ChessChallengeDev playing White: 964 - 8 - 28  [0.978] 1000
...      ChessChallengeDev playing Black: 927 - 25 - 48  [0.951] 1000
...      White vs Black: 989 - 935 - 76  [0.513] 2000
Elo difference: 573.6 +/- 35.4, LOS: 100.0 %, DrawRatio: 3.8 %

Score of ChessChallengeDev vs ChessChallenge1.34: 1332 - 505 - 663  [0.665] 2500
...      ChessChallengeDev playing White: 797 - 149 - 305  [0.759] 1251
...      ChessChallengeDev playing Black: 535 - 356 - 358  [0.572] 1249
...      White vs Black: 1153 - 684 - 663  [0.594] 2500
Elo difference: 119.4 +/- 12.1, LOS: 100.0 %, DrawRatio: 26.5 %
```

### 1.49.1
Reduce token count

Implemented by Goh CJ (cj5716)

991 tokens (-8)

```
info depth 1 score cp 42 time 34 nodes 22 nps 647 pv b1c3
info depth 2 score cp 15 time 35 nodes 82 nps 2342 pv b1c3
info depth 3 score cp 42 time 36 nodes 190 nps 5277 pv b1c3
info depth 4 score cp 15 time 37 nodes 552 nps 14918 pv b1c3
info depth 5 score cp 17 time 38 nodes 1134 nps 29842 pv b1c3
info depth 6 score cp 15 time 40 nodes 2787 nps 69675 pv b1c3
info depth 7 score cp 28 time 48 nodes 6981 nps 145437 pv b1c3
info depth 8 score cp 15 time 55 nodes 12099 nps 219981 pv b1c3
info depth 9 score cp 14 time 91 nodes 35749 nps 392846 pv b1c3
info depth 10 score cp 20 time 123 nodes 65540 nps 532845 pv b1c3
info depth 11 score cp 30 time 176 nodes 116066 nps 659465 pv b1c3
info depth 12 score cp 30 time 270 nodes 208607 nps 772618 pv b1c3
info depth 13 score cp 13 time 621 nodes 552393 nps 889521 pv b1c3
info depth 14 score cp 36 time 1084 nodes 1000291 nps 922777 pv b1c3
info depth 15 score cp 36 time 1580 nodes 1493149 nps 945031 pv b1c3
bestmove b1c3
```

### 1.50
Reverse futility pruning fail-soft

991 tokens (=)

```
info depth 1 score cp 42 time 44 nodes 22 nps 500 pv b1c3
info depth 2 score cp 15 time 45 nodes 82 nps 1822 pv b1c3
info depth 3 score cp 42 time 45 nodes 190 nps 4222 pv b1c3
info depth 4 score cp 15 time 47 nodes 552 nps 11744 pv b1c3
info depth 5 score cp 17 time 48 nodes 1134 nps 23625 pv b1c3
info depth 6 score cp 15 time 50 nodes 2787 nps 55740 pv b1c3
info depth 7 score cp 28 time 57 nodes 6981 nps 122473 pv b1c3
info depth 8 score cp 15 time 65 nodes 12074 nps 185753 pv b1c3
info depth 9 score cp 14 time 102 nodes 35644 nps 349450 pv b1c3
info depth 10 score cp 20 time 138 nodes 66453 nps 481543 pv b1c3
info depth 11 score cp 15 time 196 nodes 122453 nps 624760 pv b1c3
info depth 12 score cp 23 time 306 nodes 226899 nps 741500 pv b1c3
info depth 13 score cp 15 time 500 nodes 415023 nps 830046 pv b1c3
info depth 14 score cp 40 time 999 nodes 901024 nps 901925 pv b1c3
info depth 15 score cp 28 time 1327 nodes 1212429 nps 913661 pv b1c3
info depth 16 score cp 25 time 2040 nodes 1920485 nps 941414 pv b1c3
bestmove b1c3
```

```
Score of ChessChallenge vs ChessChallengeDev: 24880 - 23812 - 30308  [0.507] 79000
...      ChessChallenge playing White: 15898 - 8405 - 15197  [0.595] 39500
...      ChessChallenge playing Black: 8982 - 15407 - 15111  [0.419] 39500
...      White vs Black: 31305 - 17387 - 30308  [0.588] 79000
Elo difference: 4.7 +/- 1.9, LOS: 100.0 %, DrawRatio: 38.4 %
```

### 1.50.1
Reduce token count

986 tokens (-5)

```
info depth 1 score cp 42 time 46 nodes 22 nps 478 pv b1c3
info depth 2 score cp 15 time 47 nodes 82 nps 1744 pv b1c3
info depth 3 score cp 42 time 47 nodes 190 nps 4042 pv b1c3
info depth 4 score cp 15 time 48 nodes 552 nps 11500 pv b1c3
info depth 5 score cp 17 time 49 nodes 1134 nps 23142 pv b1c3
info depth 6 score cp 15 time 52 nodes 2787 nps 53596 pv b1c3
info depth 7 score cp 28 time 59 nodes 6981 nps 118322 pv b1c3
info depth 8 score cp 15 time 67 nodes 12074 nps 180208 pv b1c3
info depth 9 score cp 14 time 103 nodes 35644 nps 346058 pv b1c3
info depth 10 score cp 20 time 137 nodes 66453 nps 485058 pv b1c3
info depth 11 score cp 15 time 197 nodes 122453 nps 621588 pv b1c3
info depth 12 score cp 23 time 306 nodes 226899 nps 741500 pv b1c3
info depth 13 score cp 15 time 500 nodes 415023 nps 830046 pv b1c3
info depth 14 score cp 40 time 1001 nodes 901024 nps 900123 pv b1c3
info depth 15 score cp 28 time 1317 nodes 1212429 nps 920599 pv b1c3
info depth 16 score cp 25 time 2010 nodes 1920485 nps 955465 pv b1c3
bestmove b1c3
```

```
5+0.05
Score of ChessChallenge vs kimbo1.0: 8308 - 5411 - 3281  [0.585] 17000
...      ChessChallenge playing White: 4845 - 2081 - 1574  [0.663] 8500
...      ChessChallenge playing Black: 3463 - 3330 - 1707  [0.508] 8500
...      White vs Black: 8175 - 5544 - 3281  [0.577] 17000
Elo difference: 59.8 +/- 4.7, LOS: 100.0 %, DrawRatio: 19.3 %

40+0.4
Score of ChessChallenge vs kimbo1.0: 12420 - 5169 - 4411  [0.665] 22000
...      ChessChallenge playing White: 7187 - 1875 - 1938  [0.741] 11000
...      ChessChallenge playing Black: 5233 - 3294 - 2473  [0.588] 11000
...      White vs Black: 10481 - 7108 - 4411  [0.577] 22000
Elo difference: 119.0 +/- 4.3, LOS: 100.0 %, DrawRatio: 20.1 %
```

### 1.51
No incorrect key check for TT

982 tokens (-4)

```
info depth 1 score cp 42 time 36 nodes 22 nps 611 pv b1c3
info depth 2 score cp 15 time 37 nodes 82 nps 2216 pv b1c3
info depth 3 score cp 42 time 38 nodes 190 nps 5000 pv b1c3
info depth 4 score cp 15 time 39 nodes 552 nps 14153 pv b1c3
info depth 5 score cp 17 time 40 nodes 1134 nps 28350 pv b1c3
info depth 6 score cp 15 time 43 nodes 2787 nps 64813 pv b1c3
info depth 7 score cp 28 time 50 nodes 6981 nps 139620 pv b1c3
info depth 8 score cp 15 time 59 nodes 12079 nps 204728 pv b1c3
info depth 9 score cp 14 time 94 nodes 35651 nps 379265 pv b1c3
info depth 10 score cp 20 time 130 nodes 66433 nps 511023 pv b1c3
info depth 11 score cp 15 time 197 nodes 122474 nps 621695 pv b1c3
info depth 12 score cp 23 time 329 nodes 241763 nps 734841 pv b1c3
info depth 13 score cp 23 time 509 nodes 404416 nps 794530 pv b1c3
info depth 14 score cp 28 time 845 nodes 718761 nps 850604 pv b1c3
info depth 15 score cp 12 time 1499 nodes 1338594 nps 892991 pv b1c3
info depth 16 score cp 23 time 2233 nodes 2084044 nps 933293 pv e2e4
bestmove e2e4
```

```
Score of ChessChallenge vs ChessChallengeDev: 6385 - 6464 - 8151  [0.498] 21000
...      ChessChallenge playing White: 4161 - 2304 - 4036  [0.588] 10501
...      ChessChallenge playing Black: 2224 - 4160 - 4115  [0.408] 10499
...      White vs Black: 8321 - 4528 - 8151  [0.590] 21000
Elo difference: -1.3 +/- 3.7, LOS: 24.3 %, DrawRatio: 38.8 %
```

### 1.52
Double transposition table size

982 tokens (=)

```
info depth 1 score cp 42 time 36 nodes 22 nps 611 pv b1c3
info depth 2 score cp 15 time 37 nodes 82 nps 2216 pv b1c3
info depth 3 score cp 42 time 37 nodes 190 nps 5135 pv b1c3
info depth 4 score cp 15 time 38 nodes 552 nps 14526 pv b1c3
info depth 5 score cp 17 time 40 nodes 1134 nps 28350 pv b1c3
info depth 6 score cp 15 time 42 nodes 2787 nps 66357 pv b1c3
info depth 7 score cp 28 time 49 nodes 6981 nps 142469 pv b1c3
info depth 8 score cp 15 time 57 nodes 12073 nps 211807 pv b1c3
info depth 9 score cp 14 time 94 nodes 35641 nps 379159 pv b1c3
info depth 10 score cp 20 time 129 nodes 65348 nps 506573 pv b1c3
info depth 11 score cp 30 time 193 nodes 123557 nps 640191 pv b1c3
info depth 12 score cp 23 time 301 nodes 228415 nps 758853 pv b1c3
info depth 13 score cp 15 time 544 nodes 466081 nps 856766 pv b1c3
info depth 14 score cp 28 time 927 nodes 831548 nps 897031 pv b1c3
info depth 15 score cp 22 time 1383 nodes 1281383 nps 926524 pv b1c3
info depth 16 score cp 22 time 2257 nodes 2180876 nps 966272 pv b1c3
bestmove b1c3
```

```
5+0.05
Score of ChessChallenge vs ChessChallengeDev: 30761 - 30943 - 38296  [0.499] 100000
...      ChessChallenge playing White: 19928 - 10874 - 19198  [0.591] 50000
...      ChessChallenge playing Black: 10833 - 20069 - 19098  [0.408] 50000
...      White vs Black: 39997 - 21707 - 38296  [0.591] 100000
Elo difference: -0.6 +/- 1.7, LOS: 23.2 %, DrawRatio: 38.3 %

40+0.4
Score of ChessChallenge vs ChessChallengeDev: 2301 - 2118 - 3581  [0.511] 8000
...      ChessChallenge playing White: 1627 - 568 - 1806  [0.632] 4001
...      ChessChallenge playing Black: 674 - 1550 - 1775  [0.390] 3999
...      White vs Black: 3177 - 1242 - 3581  [0.621] 8000
Elo difference: 7.9 +/- 5.7, LOS: 99.7 %, DrawRatio: 44.8 %
```

### 1.53
No repetition detection after null move, reduce token count

Implemented by Goh CJ (cj5716)

973 tokens (-9)

```
info depth 1 score cp 42 time 33 nodes 22 nps 666 pv b1c3
info depth 2 score cp 15 time 34 nodes 82 nps 2411 pv b1c3
info depth 3 score cp 42 time 34 nodes 190 nps 5588 pv b1c3
info depth 4 score cp 15 time 35 nodes 552 nps 15771 pv b1c3
info depth 5 score cp 17 time 37 nodes 1134 nps 31500 pv b1c3
info depth 6 score cp 15 time 39 nodes 2787 nps 71461 pv b1c3
info depth 7 score cp 28 time 45 nodes 6981 nps 155133 pv b1c3
info depth 8 score cp 15 time 53 nodes 12073 nps 227792 pv b1c3
info depth 9 score cp 14 time 89 nodes 35641 nps 400460 pv b1c3
info depth 10 score cp 20 time 125 nodes 65348 nps 522784 pv b1c3
info depth 11 score cp 30 time 189 nodes 123557 nps 653740 pv b1c3
info depth 12 score cp 23 time 294 nodes 228415 nps 776921 pv b1c3
info depth 13 score cp 15 time 536 nodes 466081 nps 869554 pv b1c3
info depth 14 score cp 28 time 914 nodes 831548 nps 909789 pv b1c3
info depth 15 score cp 22 time 1361 nodes 1281371 nps 941492 pv b1c3
info depth 16 score cp 22 time 2231 nodes 2180856 nps 977523 pv b1c3
bestmove b1c3
```

```
Score of ChessChallenge vs ChessChallengeDev: 12312 - 12318 - 15370  [0.500] 40000
...      ChessChallenge playing White: 7918 - 4310 - 7771  [0.590] 19999
...      ChessChallenge playing Black: 4394 - 8008 - 7599  [0.410] 20001
...      White vs Black: 15926 - 8704 - 15370  [0.590] 40000
Elo difference: -0.1 +/- 2.7, LOS: 48.5 %, DrawRatio: 38.4 %
```

### 1.54
I changed something in evaluation.

973 tokens (=)

```
info depth 1 score cp 42 time 34 nodes 22 nps 647 pv b1c3
info depth 2 score cp 15 time 35 nodes 82 nps 2342 pv b1c3
info depth 3 score cp 42 time 35 nodes 190 nps 5428 pv b1c3
info depth 4 score cp 15 time 36 nodes 553 nps 15361 pv b1c3
info depth 5 score cp 17 time 37 nodes 1136 nps 30702 pv b1c3
info depth 6 score cp 15 time 42 nodes 3395 nps 80833 pv b1c3
info depth 7 score cp 32 time 50 nodes 7610 nps 152200 pv b1c3
info depth 8 score cp 15 time 62 nodes 13716 nps 221225 pv b1c3
info depth 9 score cp 15 time 81 nodes 27626 nps 341061 pv b1c3
info depth 10 score cp 15 time 111 nodes 48588 nps 437729 pv b1c3
info depth 11 score cp 18 time 171 nodes 100300 nps 586549 pv b1c3
info depth 12 score cp 37 time 429 nodes 352709 nps 822165 pv e2e4
info depth 13 score cp 31 time 592 nodes 518556 nps 875939 pv e2e4
info depth 14 score cp 31 time 1284 nodes 1230931 nps 958669 pv e2e4
info depth 15 score cp 31 time 1398 nodes 1344287 nps 961578 pv e2e4
info depth 16 score cp 19 time 2983 nodes 2946104 nps 987631 pv e2e4
bestmove e2e4
```

```
Score of ChessChallenge vs ChessChallengeDev: 2263 - 2120 - 2618  [0.510] 7001
...      ChessChallenge playing White: 1451 - 766 - 1283  [0.598] 3500
...      ChessChallenge playing Black: 812 - 1354 - 1335  [0.423] 3501
...      White vs Black: 2805 - 1578 - 2618  [0.588] 7001
Elo difference: 7.1 +/- 6.4, LOS: 98.5 %, DrawRatio: 37.4 %
```

### 1.55
Remove material, quantize PSTs by 8

956 tokens (-17)

```
info depth 1 score cp 44 time 34 nodes 22 nps 647 pv b1c3
info depth 2 score cp 15 time 35 nodes 82 nps 2342 pv b1c3
info depth 3 score cp 44 time 35 nodes 190 nps 5428 pv b1c3
info depth 4 score cp 15 time 36 nodes 507 nps 14083 pv b1c3
info depth 5 score cp 15 time 37 nodes 1117 nps 30189 pv b1c3
info depth 6 score cp 15 time 39 nodes 2675 nps 68589 pv b1c3
info depth 7 score cp 28 time 45 nodes 6320 nps 140444 pv b1c3
info depth 8 score cp 15 time 59 nodes 13325 nps 225847 pv b1c3
info depth 9 score cp 20 time 74 nodes 24412 nps 329891 pv b1c3
info depth 10 score cp 24 time 110 nodes 52959 nps 481445 pv b1c3
info depth 11 score cp 17 time 168 nodes 106848 nps 636000 pv b1c3
info depth 12 score cp 15 time 361 nodes 289397 nps 801653 pv b1c3
info depth 13 score cp 16 time 1165 nodes 1074175 nps 922038 pv e2e4
info depth 14 score cp 30 time 1451 nodes 1356363 nps 934778 pv e2e4
info depth 15 score cp 22 time 1984 nodes 1887187 nps 951203 pv e2e4
bestmove e2e4
```

```
Score of ChessChallenge vs ChessChallengeDev: 4749 - 4853 - 5398  [0.497] 15000
...      ChessChallenge playing White: 3049 - 1754 - 2697  [0.586] 7500
...      ChessChallenge playing Black: 1700 - 3099 - 2701  [0.407] 7500
...      White vs Black: 6148 - 3454 - 5398  [0.590] 15000
Elo difference: -2.4 +/- 4.4, LOS: 14.4 %, DrawRatio: 36.0 %
```

### 1.56
Full PSTs, quantize PSTs by 12, decimal encoding for eval terms

993 tokens (+37)

```
info depth 1 score cp 49 time 35 nodes 23 nps 657 pv g1f3
info depth 2 score cp 15 time 36 nodes 84 nps 2333 pv g1f3
info depth 3 score cp 41 time 36 nodes 211 nps 5861 pv g1f3
info depth 4 score cp 15 time 38 nodes 572 nps 15052 pv g1f3
info depth 5 score cp 37 time 39 nodes 1124 nps 28820 pv g1f3
info depth 6 score cp 15 time 42 nodes 2884 nps 68666 pv g1f3
info depth 7 score cp 39 time 47 nodes 5869 nps 124872 pv g1f3
info depth 8 score cp 15 time 56 nodes 12143 nps 216839 pv g1f3
info depth 9 score cp 11 time 81 nodes 29270 nps 361358 pv g1f3
info depth 10 score cp 21 time 177 nodes 111657 nps 630830 pv e2e4
info depth 11 score cp 35 time 252 nodes 183617 nps 728638 pv e2e4
info depth 12 score cp 41 time 356 nodes 286455 nps 804648 pv e2e4
info depth 13 score cp 35 time 551 nodes 479661 nps 870528 pv e2e4
info depth 14 score cp 36 time 961 nodes 899734 nps 936247 pv e2e4
info depth 15 score cp 15 time 2299 nodes 2269875 nps 987331 pv g1f3
bestmove g1f3
```

```
Score of ChessChallenge vs ChessChallengeDev: 2920 - 2465 - 2615  [0.528] 8000
...      ChessChallenge playing White: 1780 - 911 - 1310  [0.609] 4001
...      ChessChallenge playing Black: 1140 - 1554 - 1305  [0.448] 3999
...      White vs Black: 3334 - 2051 - 2615  [0.580] 8000
Elo difference: 19.8 +/- 6.2, LOS: 100.0 %, DrawRatio: 32.7 %
```

### 1.57
Tapered evaluation, remove bishop pair evaluation, revert to split PSTs quantized by 8

Evaluation implemented by Gediminas Masaitis, size reduction by Goh CJ (cj5716)

1023 tokens (+30)

```
info depth 1 score cp 44 time 35 nodes 22 nps 628 pv b1c3
info depth 2 score cp 15 time 36 nodes 82 nps 2277 pv b1c3
info depth 3 score cp 36 time 36 nodes 190 nps 5277 pv b1c3
info depth 4 score cp 15 time 37 nodes 548 nps 14810 pv b1c3
info depth 5 score cp 19 time 39 nodes 1198 nps 30717 pv b1c3
info depth 6 score cp 15 time 42 nodes 2907 nps 69214 pv b1c3
info depth 7 score cp 30 time 46 nodes 5722 nps 124391 pv b1c3
info depth 8 score cp 15 time 54 nodes 10616 nps 196592 pv b1c3
info depth 9 score cp 5 time 74 nodes 23980 nps 324054 pv b1c3
info depth 10 score cp 12 time 109 nodes 51690 nps 474220 pv b1c3
info depth 11 score cp 31 time 194 nodes 128546 nps 662608 pv g1f3
info depth 12 score cp 26 time 346 nodes 279007 nps 806378 pv g1f3
info depth 13 score cp 26 time 537 nodes 469017 nps 873402 pv g1f3
info depth 14 score cp 24 time 921 nodes 846386 nps 918985 pv g1f3
info depth 15 score cp 15 time 2847 nodes 2769443 nps 972758 pv b1c3
bestmove b1c3
```

```
Score of ChessChallenge vs ChessChallengeDev: 2031 - 1652 - 1317  [0.538] 5000
...      ChessChallenge playing White: 1246 - 605 - 649  [0.628] 2500
...      ChessChallenge playing Black: 785 - 1047 - 668  [0.448] 2500
...      White vs Black: 2293 - 1390 - 1317  [0.590] 5000
Elo difference: 26.4 +/- 8.3, LOS: 100.0 %, DrawRatio: 26.3 %

Score of ChessChallenge vs ChessChallenge1.34: 923 - 273 - 304  [0.717] 1500
...      ChessChallenge playing White: 518 - 105 - 128  [0.775] 751
...      ChessChallenge playing Black: 405 - 168 - 176  [0.658] 749
...      White vs Black: 686 - 510 - 304  [0.559] 1500
Elo difference: 161.2 +/- 16.9, LOS: 100.0 %, DrawRatio: 20.3 %

Score of ChessChallenge vs ChessChallengeTier2: 1433 - 18 - 49  [0.972] 1500
...      ChessChallenge playing White: 730 - 5 - 16  [0.983] 751
...      ChessChallenge playing Black: 703 - 13 - 33  [0.961] 749
...      White vs Black: 743 - 708 - 49  [0.512] 1500
Elo difference: 614.1 +/- 45.3, LOS: 100.0 %, DrawRatio: 3.3 %
```

### 1.58
Only increase reduction in LMR for zero-window nodes if we are not in check

Implemented by Goh CJ (cj5716)

1020 tokens (-3)

```
info depth 1 score cp 44 time 36 nodes 22 nps 611 pv b1c3
info depth 2 score cp 15 time 36 nodes 82 nps 2277 pv b1c3
info depth 3 score cp 36 time 36 nodes 190 nps 5277 pv b1c3
info depth 4 score cp 15 time 37 nodes 548 nps 14810 pv b1c3
info depth 5 score cp 19 time 39 nodes 1198 nps 30717 pv b1c3
info depth 6 score cp 15 time 42 nodes 2907 nps 69214 pv b1c3
info depth 7 score cp 30 time 46 nodes 5722 nps 124391 pv b1c3
info depth 8 score cp 15 time 54 nodes 10616 nps 196592 pv b1c3
info depth 9 score cp 5 time 74 nodes 23980 nps 324054 pv b1c3
info depth 10 score cp 12 time 113 nodes 51690 nps 457433 pv b1c3
info depth 11 score cp 31 time 201 nodes 128609 nps 639845 pv g1f3
info depth 12 score cp 26 time 396 nodes 309872 nps 782505 pv g1f3
info depth 13 score cp 26 time 570 nodes 472481 nps 828914 pv g1f3
info depth 14 score cp 24 time 1222 nodes 1114833 nps 912301 pv g1f3
info depth 15 score cp 15 time 1869 nodes 1743535 nps 932870 pv g1f3
bestmove g1f3
```

```
Score of ChessChallenge vs ChessChallengeDev: 7765 - 7767 - 10468  [0.500] 26000
...      ChessChallenge playing White: 5098 - 2675 - 5228  [0.593] 13001
...      ChessChallenge playing Black: 2667 - 5092 - 5240  [0.407] 12999
...      White vs Black: 10190 - 5342 - 10468  [0.593] 26000
Elo difference: -0.0 +/- 3.3, LOS: 49.4 %, DrawRatio: 40.3 %
```

### 1.59
More reduction if history is negative

1018 tokens (-2)

```
info depth 1 score cp 44 time 36 nodes 22 nps 611 pv b1c3
info depth 2 score cp 15 time 37 nodes 82 nps 2216 pv b1c3
info depth 3 score cp 36 time 37 nodes 190 nps 5135 pv b1c3
info depth 4 score cp 15 time 39 nodes 548 nps 14051 pv b1c3
info depth 5 score cp 19 time 40 nodes 1192 nps 29800 pv b1c3
info depth 6 score cp 15 time 43 nodes 2664 nps 61953 pv b1c3
info depth 7 score cp 30 time 46 nodes 4750 nps 103260 pv b1c3
info depth 8 score cp 15 time 56 nodes 10134 nps 180964 pv b1c3
info depth 9 score cp 5 time 89 nodes 31894 nps 358359 pv b1c3
info depth 10 score cp 19 time 111 nodes 49038 nps 441783 pv b1c3
info depth 11 score cp 9 time 167 nodes 98750 nps 591317 pv b1c3
info depth 12 score cp 19 time 233 nodes 162958 nps 699390 pv b1c3
info depth 13 score cp 19 time 314 nodes 241770 nps 769968 pv b1c3
info depth 14 score cp 14 time 681 nodes 609842 nps 895509 pv b1c3
info depth 15 score cp 17 time 1603 nodes 1535966 nps 958182 pv b1c3
bestmove b1c3
```

```
Score of ChessChallenge vs ChessChallengeDev: 13177 - 12547 - 17276  [0.507] 43000
...      ChessChallenge playing White: 8672 - 4195 - 8633  [0.604] 21500
...      ChessChallenge playing Black: 4505 - 8352 - 8643  [0.411] 21500
...      White vs Black: 17024 - 8700 - 17276  [0.597] 43000
Elo difference: 5.1 +/- 2.5, LOS: 100.0 %, DrawRatio: 40.2 %
```

### 1.60
No NMP if there are only pawns left

Implemented by Goh CJ (cj5716)

1022 tokens (+4)

```
info depth 1 score cp 44 time 47 nodes 22 nps 468 pv b1c3
info depth 2 score cp 15 time 48 nodes 82 nps 1708 pv b1c3
info depth 3 score cp 36 time 48 nodes 190 nps 3958 pv b1c3
info depth 4 score cp 15 time 50 nodes 548 nps 10960 pv b1c3
info depth 5 score cp 19 time 51 nodes 1192 nps 23372 pv b1c3
info depth 6 score cp 15 time 53 nodes 2664 nps 50264 pv b1c3
info depth 7 score cp 30 time 58 nodes 4750 nps 81896 pv b1c3
info depth 8 score cp 15 time 68 nodes 10134 nps 149029 pv b1c3
info depth 9 score cp 5 time 109 nodes 31894 nps 292605 pv b1c3
info depth 10 score cp 19 time 139 nodes 49038 nps 352791 pv b1c3
info depth 11 score cp 9 time 198 nodes 98750 nps 498737 pv b1c3
info depth 12 score cp 19 time 269 nodes 162958 nps 605791 pv b1c3
info depth 13 score cp 19 time 352 nodes 241770 nps 686846 pv b1c3
info depth 14 score cp 14 time 713 nodes 609842 nps 855318 pv b1c3
info depth 15 score cp 17 time 1605 nodes 1535966 nps 956988 pv b1c3
bestmove b1c3
```

```
Score of ChessChallenge vs ChessChallengeDev: 3647 - 3417 - 4936  [0.510] 12000
...      ChessChallenge playing White: 2413 - 1174 - 2414  [0.603] 6001
...      ChessChallenge playing Black: 1234 - 2243 - 2522  [0.416] 5999
...      White vs Black: 4656 - 2408 - 4936  [0.594] 12000
Elo difference: 6.7 +/- 4.8, LOS: 99.7 %, DrawRatio: 41.1 %
```

### 1.60.1
Reduce token count

Implemented by Goh CJ (cj5716)

1016 tokens (-6)

```
info depth 1 score cp 44 time 35 nodes 22 nps 628 pv b1c3
info depth 2 score cp 15 time 36 nodes 82 nps 2277 pv b1c3
info depth 3 score cp 36 time 36 nodes 190 nps 5277 pv b1c3
info depth 4 score cp 15 time 38 nodes 548 nps 14421 pv b1c3
info depth 5 score cp 19 time 39 nodes 1192 nps 30564 pv b1c3
info depth 6 score cp 15 time 42 nodes 2664 nps 63428 pv b1c3
info depth 7 score cp 30 time 45 nodes 4750 nps 105555 pv b1c3
info depth 8 score cp 15 time 54 nodes 10134 nps 187666 pv b1c3
info depth 9 score cp 5 time 107 nodes 31894 nps 298074 pv b1c3
info depth 10 score cp 19 time 132 nodes 49038 nps 371500 pv b1c3
info depth 11 score cp 9 time 194 nodes 98750 nps 509020 pv b1c3
info depth 12 score cp 19 time 274 nodes 162958 nps 594737 pv b1c3
info depth 13 score cp 19 time 364 nodes 241770 nps 664203 pv b1c3
info depth 14 score cp 14 time 744 nodes 609842 nps 819680 pv b1c3
info depth 15 score cp 17 time 1662 nodes 1535966 nps 924167 pv b1c3
bestmove b1c3
```

```
Score of ChessChallengeDev vs ChessChallenge1.34: 6245 - 1834 - 1921  [0.721] 10000
...      ChessChallengeDev playing White: 3560 - 613 - 827  [0.795] 5000
...      ChessChallengeDev playing Black: 2685 - 1221 - 1094  [0.646] 5000
...      White vs Black: 4781 - 3298 - 1921  [0.574] 10000
Elo difference: 164.5 +/- 6.6, LOS: 100.0 %, DrawRatio: 19.2 %
```

### 1.61 - Version submitted to the challenge

Use TT score to adjust evaluation, and only do TT cutoffs on non-PV nodes.
Also moves TT back in front of pruning so that changes to eval can affect it.

Implemented by Goh CJ (cj5716)

1023 tokens (+7)

```
info depth 1 score cp 44 time 35 nodes 22 nps 628 pv b1c3
info depth 2 score cp 15 time 35 nodes 82 nps 2342 pv b1c3
info depth 3 score cp 36 time 36 nodes 190 nps 5277 pv b1c3
info depth 4 score cp 15 time 37 nodes 548 nps 14810 pv b1c3
info depth 5 score cp 19 time 38 nodes 1191 nps 31342 pv b1c3
info depth 6 score cp 15 time 41 nodes 2600 nps 63414 pv b1c3
info depth 7 score cp 30 time 46 nodes 4616 nps 100347 pv b1c3
info depth 8 score cp 15 time 55 nodes 9776 nps 177745 pv b1c3
info depth 9 score cp 5 time 90 nodes 32701 nps 363344 pv b1c3
info depth 10 score cp 31 time 131 nodes 64759 nps 494343 pv b1c3
info depth 11 score cp 20 time 206 nodes 128383 nps 623218 pv g1f3
info depth 12 score cp 18 time 370 nodes 280002 nps 756762 pv b1c3
info depth 13 score cp 21 time 526 nodes 422077 nps 802427 pv b1c3
info depth 14 score cp 16 time 952 nodes 816227 nps 857381 pv b1c3
info depth 15 score cp 18 time 1795 nodes 1599172 nps 890903 pv e2e4
bestmove e2e4
```

5+0.05 tests:
```
Score of ChessChallenge vs ChessChallengeDev: 1953 - 1690 - 2357  [0.522] 6000
...      ChessChallenge playing White: 1289 - 555 - 1157  [0.622] 3001
...      ChessChallenge playing Black: 664 - 1135 - 1200  [0.421] 2999
...      White vs Black: 2424 - 1219 - 2357  [0.600] 6000
Elo difference: 15.2 +/- 6.8, LOS: 100.0 %, DrawRatio: 39.3 %

Score of ChessChallenge vs ChessChallengeTier2: 9625 - 60 - 315  [0.978] 10000
...      ChessChallenge playing White: 4898 - 9 - 93  [0.989] 5000
...      ChessChallenge playing Black: 4727 - 51 - 222  [0.968] 5000
...      White vs Black: 4949 - 4736 - 315  [0.511] 10000
Elo difference: 661.2 +/- 18.6, LOS: 100.0 %, DrawRatio: 3.1 %

Score of ChessChallenge vs ChessChallenge1.34: 6328 - 1678 - 1994  [0.733] 10000
...      ChessChallenge playing White: 3543 - 600 - 857  [0.794] 5000
...      ChessChallenge playing Black: 2785 - 1078 - 1137  [0.671] 5000
...      White vs Black: 4621 - 3385 - 1994  [0.562] 10000
Elo difference: 175.0 +/- 6.6, LOS: 100.0 %, DrawRatio: 19.9 %

Score of ChessChallenge vs 4ku1.0: 3623 - 4094 - 2283  [0.476] 10000
...      ChessChallenge playing White: 2185 - 1601 - 1214  [0.558] 5000
...      ChessChallenge playing Black: 1438 - 2493 - 1069  [0.395] 5000
...      White vs Black: 4678 - 3039 - 2283  [0.582] 10000
Elo difference: -16.4 +/- 6.0, LOS: 0.0 %, DrawRatio: 22.8 %
```

60+0.6 tests:
```
Score of ChessChallenge vs 4ku1.0: 1927 - 1061 - 1012  [0.608] 4000
...      ChessChallenge playing White: 1143 - 343 - 514  [0.700] 2000
...      ChessChallenge playing Black: 784 - 718 - 498  [0.516] 2000
...      White vs Black: 1861 - 1127 - 1012  [0.592] 4000
Elo difference: 76.4 +/- 9.4, LOS: 100.0 %, DrawRatio: 25.3 %
```