inputFile = open(r"./Day3/input.txt", "r")
field = []
width = 0
height = 0

def create_field_array():
    for line in inputFile:
        row = []

        for character in line:
            if character == '\n':
                break
            row.append(character)
        field.append(row)


create_field_array()
width = len(field[0])
height = len(field)
def calculate_trees(movement_x, movement_y):
    trees = 0
    x = 0
    y = 0
    for row in field:
        x += movement_x
        if x >= width:
            x -= width
        y += movement_y
        if y >= height:
            break
        if field[y][x] == "#":
            trees += 1
    return trees

print(calculate_trees(1, 1) * calculate_trees(3, 1) * calculate_trees(5, 1) * calculate_trees(7, 1) * calculate_trees(1, 2))