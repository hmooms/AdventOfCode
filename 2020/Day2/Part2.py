import re

inputFile = open(r"D:\Projects\adventofcode\2020\Day2\input.txt", "r")
inputArray = []

def create_input_array():

    dictionary = {}

    for line in inputFile:
        splitLine = line.split(' ')
        for split in splitLine:
            if (split.find('-') >= 0):
                min_position = int(split.split('-')[0])
                max_position = int(split.split('-')[1])
            elif (split.find(':') >= 0):
                letter = split.replace(':', '')
            elif (split.find('\n') >= 0):
                password = split.replace('\n', '')
            else :
                password = split
        
        dictionary = {'max': max_position, 'min': min_position, 'letter': letter, 'pw': password}
        
        inputArray.append(dictionary.copy())
    
    return inputArray

def check_passwords():
    correctPasswords = 0
    for dictionary in inputArray:
        same_position = 0
        for index, character in enumerate(dictionary['pw']):
            index += 1
            if character == dictionary['letter'] and (index == dictionary['min'] or index == dictionary['max']):
                same_position += 1
        if (same_position == 1):
            correctPasswords += 1
    print(f"Er zijn {correctPasswords} goede wachtwoorden.")


create_input_array()
check_passwords()