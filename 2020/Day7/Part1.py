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


    for can_contain_color



 """

input_file = open(r"./2020/Day7/input.txt", "r")

bags = []


def set_bags():
    for line in input_file:
        bag = {}
        if line.find("contain no other bags.") > 1:
            continue
        line = line.replace("\n", '')
        split_line = line.split(' ')
        bag['color'] = f"{split_line[0]} {split_line[1]}"

        can_contain = []
        for i, word in enumerate(split_line):
            if word.find('bag') >= 0:
                color = f"{split_line[i - 2]} {split_line[i - 1]}"
                # print(color)
                if bag['color'] != color:
                    can_contain.append(color)
            if word.find('.') >= 0:
                bag['can_contain'] = can_contain
                can_contain = []

        bags.append(bag)


def check_what_bags_can_contain(color):
    can_contain = checked_bag = []
    if color not in can_contain:
        can_contain.append(color)

    for can_contain_color in can_contain:
        # print(can_contain)
        for bag in bags:
            # print(bag)
            if bag['color'] not in can_contain:
                if can_contain_color in bag['can_contain']:
                    # print(can_contain, bag['color'])
                    can_contain.append(bag['color'])
        checked_bag.append(can_contain_color)
    print(can_contain)


set_bags()
color = 'shiny gold'
# check_what_bags_can_contain(color)

print(bags)
