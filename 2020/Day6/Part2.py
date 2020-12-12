input_file = open(r"./Day6/input.txt", "r")

answer_groups = []


def set_answer_groups():
    group = []
    line_count = sum(1 for line in open(r"./Day6/input.txt", "r"))
    answers = []
    people_in_group = 0
    for i, line in enumerate(input_file):
        if line == '\n':
            group.append(answers)
            group.append(people_in_group)
            answer_groups.append(group)
            group = []
            answers = []
            people_in_group = 0
            continue
        people_in_group += 1
        line = line.replace('\n', '')

        for char in line:
            answers.append(char)

        if i == line_count - 1:
            group.append(answers)
            group.append(people_in_group)
            answer_groups.append(group)

    for i, group in enumerate(answer_groups):
        tmp_array = []
        for char in group[0]:
            if group[0].count(char) == group[1] and char not in tmp_array:
                tmp_array.append(char)
        answer_groups[i] = tmp_array


def get_sum_answers():
    count = 0
    for group in answer_groups:
        count += len(group)
    print(count)


set_answer_groups()
get_sum_answers()
# print(answer_groups)
