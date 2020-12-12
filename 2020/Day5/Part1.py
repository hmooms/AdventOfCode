input_file = open(r"./Day5/input.txt", "r")
seats = []
seat_locations = []


def create_seats_array():
    for line in input_file:
        seat = {'row': None, 'col': None}
        if line.endswith('\n'):
            line.replace('\n', '')
        seat['row'] = line[0:7]
        seat['col'] = line[7:10]
        seats.append(seat)


def get_seat_locations():
    for seat in seats:
        seat_location = {}
        seat_location['row'] = get_seat_row(seat['row'])
        seat_location['col'] = get_seat_column(seat['col'])
        seat_location['id'] = get_seat_id(
            seat_location['row'], seat_location['col'])
        seat_locations.append(seat_location)


def get_seat_row(row):
    rows = [0, 127]
    for char in row:
        row_diff = int(rows[1] - rows[0])
        if char == 'F':
            rows[1] -= int(row_diff / 2) + 1
        elif char == 'B':
            rows[0] += int(row_diff / 2) + 1

    return rows[0]


def get_seat_column(col):
    cols = [0, 7]
    for char in col:
        col_diff = int(cols[1] - cols[0])
        if char == 'L':
            cols[1] -= int(col_diff / 2) + 1
        elif char == 'R':
            cols[0] += int(col_diff / 2) + 1

    return cols[0]


def get_seat_id(row, col):
    return row * 8 + col


def find_highest_id():
    highest_id = 0
    for location in seat_locations:
        if location['id'] > highest_id:
            highest_id = location['id']
    print(highest_id)


create_seats_array()
get_seat_locations()
find_highest_id()
