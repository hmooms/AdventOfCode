""" 
    small idea: 
    
    bags [
        {'color': "", 'can_contain': ['color']},
    ]

    if bag cant contain anything dont add

    start with shiny gold

    for bag in bags

    checked_bags ["color", ..]
    can_contain ["color", ..]

 """

input_file = open(r"AdventOfCode/2020/Day7/input.txt", "r")

bags = []

for line in input_file:
    bag = {}
    if line.find("contain no other bags."):
        continue
    line = line.replace("\n", "")
    split_line = line.split(" ")
    bag = {'color': f"{split_line[0]} {split_line[1]}"}

    bags.append(bag)

print(bags)