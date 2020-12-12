import re
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
        valid_fields = True

        for key, field in passport.items():
            # print(key, field)
            if (validate_field(key, field) == False):
                valid_fields = False

        if valid_fields and (len(passport) == 8 or (len(passport) == 7 and 'cid' not in passport)):
            # print(valid_fields)
            valid_passports += 1
    return valid_passports


def validate_field(key, field):
    eye_colors = ['amb', 'blu', 'brn', 'gry', 'grn', 'hzl', 'oth']
    if key == 'byr':
        field = int(field)
        return (field >= 1920 and field <= 2002)
    elif key == 'iyr':
        field = int(field)
        return (field >= 2010 and field <= 2020)
    elif key == 'eyr':
        field = int(field)
        return (field >= 2020 and field <= 2030)
    elif key == 'hgt':
        if field.endswith('cm'):
            field = int(field.replace('cm', ''))
            return (field >= 150 and field <= 193)
        elif field.endswith('in'):
            field = int(field.replace('in', ''))
            return (field >= 59 and field <= 76)
        else:
            return False
    elif key == 'hcl':
        if field.startswith('#'):
            return bool(re.match(r"(#)[a-f0-9]{6}", field))
        else:
            return False
    elif key == 'ecl':
        return field in eye_colors
    elif key == 'pid':
        if len(field) == 9:
            return bool(re.match(r"[0-9]", field))
        else:
            return False
    elif key == 'cid':
        return True


create_passports_array()
valid_passports = num_valid_passports()

print(f"{valid_passports} / {len(passports)}")
