inputFile = open(r"./Day4/input.txt", "r")
passports = []
valid_passports = 0
def create_passports_array():
    passport = {}
    line_count = sum(1 for line in open(r"./Day4/input.txt", "r"))
    for i, line in enumerate(inputFile):
        if line == "\n":
            passports.append(passport)
            passport = {}
            continue
        
        splitLine = line.split(' ')

        for split in splitLine:
            if split.find('/n'):
                split = split.replace('\n', '')

            split = split.split(':')

            passport[split[0]] = split[1]
        if i == line_count - 1:
            passports.append(passport)

def num_valid_passports():
    valid_passports = 0
    for passport in passports:
        if len(passport) == 8 or (len(passport) == 7 and 'cid' not in passport):
            valid_passports += 1
    return valid_passports

create_passports_array()
valid_passports = num_valid_passports()
print(f"{valid_passports} / {len(passports)}")