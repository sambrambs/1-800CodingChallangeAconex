
Feature: Command line Application for Phone numbers conversion
In order to convert Phone number to valid words,
as a user,
I want an application that launches 1-800 through the command line
@Ignore
Scenario: A Valid command line with both arguments present
Given a input file Input\inputFile.txt containing numbers
"""
228
456
"""
And a dictionary file Dictionary\dictionaryFile.txt conining words
"""
cat
dog
lion
"""
When I run 1-800App -I Input\inputFile.txt -D Dictionary\dictionaryFile.txt
Then there exists the file Results\Result.txt containing
"""
cat
"""
@Ignore
Scenario: A Valid command line where file argument is missing
Given a dictionary file Dictionary\dictionaryFile.txt conining words
"""
cat
dog
lion
"""
And ConsoleService is up and running
When I run 1-800App -D Dictionary\dictionaryFile.txt
Then ConsoleService recieves the input
"""
228
456
"""
Then there exists the file Results\Result.txt containing
"""
cat
"""
@Ignore
Scenario: A Valid command line when dictionary argument is missing
Given a default dictionary file Defaults\dictionaryFile.txt conining words
"""
cat
dog
lion
"""
And ConsoleService is up and running
When I run 1-800App
Then ConsoleService recieves the input
"""
228
456
"""
Then there exists the file Results\Result.txt containing
"""
cat
"""
@Ignore
Scenario: A Valid command line when dictionary argument is present overrides def
ault dictionary
Given a default dictionary file Defaults\dictionaryFile.txt conining words
"""
dog
lion
"""
And a dictionary file Dictionary\dictionaryFile.txt conining words
"""
cat
dog
lion
"""
And ConsoleService is up and running
When I run 1-800App -D Dictionary\dictionaryFile.txt
Then ConsoleService recieves the input
"""
228
456
"""
Then there exists the file Results\Result.txt containing
"""
cat
"""
