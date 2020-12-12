import re

inputFile = open(r"./Day2/input.txt", "r")
inputArray = []

def create_input_array():

    dictionary = {}

    for line in inputFile:
        splitLine = line.split(' ')
        for split in splitLine:
            if (split.find('-') >= 0):
                min_amount = int(split.split('-')[0])
                max_amount = int(split.split('-')[1])
            elif (split.find(':') >= 0):
                letter = split.replace(':', '')
            elif (split.find('\n') >= 0):
                password = split.replace('\n', '')
        
        dictionary = {'max': max_amount, 'min': min_amount, 'letter': letter, 'pw': password}
        
        inputArray.append(dictionary.copy())
    
    return inputArray

def check_passwords():
    correctPasswords = 0
    for dictionary in inputArray:
        if (dictionary['pw'].count(dictionary['letter']) >= dictionary['min'] and dictionary['pw'].count(dictionary['letter']) <= dictionary['max']):
            correctPasswords += 1
    print(f"Er zijn {correctPasswords} goede wachtwoorden.")


create_input_array()
check_passwords()