input_file = open(r"./Day6/input.txt", "r")

answer_groups = []


def set_answer_groups():
    group = []
    line_count = sum(1 for line in open(r"./Day6/input.txt", "r"))

    for i, line in enumerate(input_file):
        if line == '\n':
            answer_groups.append(group)
            group = []
            continue

        line = line.replace('\n', '')
        for char in line:
            if char not in group:
                group.append(char)

        if i == line_count - 1:
            answer_groups.append(group)


def get_sum_answers():
    count = 0
    for group in answer_groups:
        count += len(group)
    print(count)


set_answer_groups()
get_sum_answers()
print(answer_groups)
