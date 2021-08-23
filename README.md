# Subset-Anagrams
A program that takes an input string of characters and outputs anagrams of the subset of this input.

Flow of program:
-Asks for user to input a word or some characters, say "sheep"
-Program searches a text file of words for any that fit into the input. In this case, some of the output words would be "sheep", "she", and "pee".

Method for doing so:
-Each letter of the alphabet is assigned a unique prime, i.e. a=2, b=3, c=5,... .
-A word can be identified using the product of its character's primes. i.e. The prime product of "abc" = 2*3*5.
-A world 'Word 1' can be checked to be an anagram of another word 'Word 2' or it's subset. The check returns true if the prime product of Word 1 divides into Word 2.
-I.e. Consider prime products of: "ab" = 2*3, "abc" = 2*3*5. In this case the prime product of "ab" divides into "abc". This tells us that "ab" is an anagram of "abc" or the subset of "abc".
