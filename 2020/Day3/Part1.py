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

def calculate_trees():
    trees = 0
    x = 0
    y = 0
    for row in field:
        x += 3
        if x >= width:
            x -= width
        y += 1
        if y >= height:
            break
        if field[y][x] == "#":
            trees += 1
    print(f"Er zijn {trees} bomen")

calculate_trees()