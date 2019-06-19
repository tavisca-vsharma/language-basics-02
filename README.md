## Problem statement

In this problem we are using 24-hour time. That is, the first second of each day is 00:00:00 and the last second of each day is 23:59:59.

You are visiting an online forum. Whenever there is a post that has been made strictly less than 24 hours ago, the forum displays a human-readable message stating when it was made. There are three types of messages:

* `few seconds ago`, which means the post is made between 0 and 59 seconds ago, inclusive.

* `X minutes ago`, where X is an integer between 1 and 59, inclusive, which means the post is made between X minutes and X minutes 59 seconds ago, inclusive.

* `X hours ago`, where X is an integer between 1 and 23, inclusive, which means the post is made between X hours and X hours 59 minutes 59 seconds ago, inclusive.

You are given the string[]s exactPostTime and showPostTime, both with the same number of elements. For each valid index i you know the following information:

* Post i was made strictly less than 24 hours ago.
* The exact time of day when post i was made is exactPostTime[i].
* The human-readable string currently displayed by the forum software about post i is showPostTime[i].

Given all the information above, what is the current time?

Return the answer in the format "HH:MM:SS". If there are multiple solutions, return the one that comes first lexicographically. If the information given to you is self-contradictory and there is no solution, return "impossible" instead.


## Definition

**Class**:	`ForumPostEasy`

**Method**:	`GetCurrentTime`

**Parameters**:	`string[], string[]``

**Returns**:	`string`

**Method signature**:	`string GetCurrentTime(string[] exactPostTime, string[] showPostTime)`
(be sure your method is public)


## Notes
*	The lexicographically smaller of two equally-long strings is the one that has a character with a smaller ASCII value at the first index at which they differ.

## Constraints
*	exactPostTime will contain between 0 and 50 elements, inclusive.
*	Each element of exactPostTime will be formatted as HH:MM:SS where HH is a two-digit integer between 00 and 23, inclusive, and both MM and SS are two-digit integers between 00 and 59, inclusive.
*	exactPostTime and showPostTime will contain same number of elements.
*	Each element of showPostTime will have one of the formats described in problem statment.

## Examples
**1**

{"12:12:12"}

{"few seconds ago"}

Returns: "12:12:12"

The current time is somewhere between 12:12:12 and 12:13:11, inclusive. The returned time is the lexicographically smallest one out of all these times.

**2**

{"23:23:23","23:23:23"}

{"59 minutes ago","59 minutes ago"}

Returns: "00:22:23"

Both posts were made on the previous day. The current time is a bit after midnight.

**3**		

{"00:10:10","00:10:10"}

{"59 minutes ago","1 hours ago"}

Returns: "impossible"

Two posts made in the same second cannot have two different human-readable strings.

**4**		

{"11:59:13","11:13:23","12:25:15"}

{"few seconds ago","46 minutes ago","23 hours ago"}

Returns: "11:59:23"

The post made at 12:25:15 was posted yesterday at that time of day.
