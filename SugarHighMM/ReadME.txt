Sugar High

Problem

You have just finished Trick-or-Treating, and you cannot wait to enjoy all of the candy that you have gotten. However, there's one problem - you can get sugar high from eating too much candy! You would like to enjoy as many pieces of candy as possible at once before you get sugar high.
You are given an array of integers, candies, where each element represents the grams of sugar that each candy has. You are also given a threshold which is how many grams of sugar that you can consume at once before you get sugar high. You task is to output an array of indices of the candies that you can enjoy at once before crossing your sugar high threshold.
Note:
Your main priority is to eat the maximum number of candies possible, but if there are multiple ways of doing this, choose the one with the fewest grams of sugar total.
If there's still a tie, choose the lower indices.

Example

For candies = [33, 20, 12, 19, 29] and threshold = 33, the output should be sugarHigh(candies, threshold) = [2, 3].
Although [1, 2] is also valid, The candies at indices 2 and 3 have a lesser sum (12 + 19 = 31) than the candies at indices 1 and 2 (20 + 12 = 32).
For candies = [62, 67, 100] and threshold = 8, the output should be sugarHigh(candies, threshold) = [].
All of the candies have more sugar than you can handle, so you cannot have any candy.
For candies = [16, 39, 67, 16, 38, 71] and threshold = 17, the output should be sugarHigh(candies, threshold) = [0].
Although index 3 is also valid, the first candy in the list appeared earlier.
For candies = [16, 3, 14, 17, 11] and threshold = 99, the output should be sugarHigh(candies, threshold) = [0, 1, 2, 3, 4].
The candies that you collected have a total of 16 + 3 + 14 + 17 + 11 = 72 grams of sugar compared to your threshold of 99 grams, so you can have all of your candy!

If a candy repeats...
 [1, 6, 3, 7, 2, 3]  treshold 15  
=> [0, 1, 2, 4, 5]  :)