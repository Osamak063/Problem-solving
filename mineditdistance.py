def minNum(x, y, z):
    if x <= y and x <= z:
        return x
    elif y <= x and y <= z:
        return y
    else:
        return z


str1 = input('Enter String one')
str2 = input('Enter String two')
listStr1 = list(str1)
listStr2 = list(str2)
matrix = []
for i in range(len(listStr2) + 1):
    matrix.append([])
    for j in range(len(listStr1) + 1):
        matrix[i].append([])
emptyStringRow = 0
emptyStringCol = 0
for row in range(0, len(listStr2) + 1):
    for col in range(0, len(listStr1) + 1):
        if row == 0 and col == 0:
            matrix[row][col] = 0
            emptyStringRow = emptyStringRow + 1
            emptyStringCol = emptyStringCol + 1
        elif row == 0 or col == 0:
            if row == 0:
                matrix[row][col] = emptyStringRow
                emptyStringRow = emptyStringRow + 1
            elif col == 0:
                matrix[row][col] = emptyStringCol
                emptyStringCol = emptyStringCol + 1
        else:
            if listStr2[row - 1] == listStr1[col - 1]:
                matrix[row][col] = matrix[row - 1][col - 1]
            else:
                matrix[row][col] = minNum(matrix[row - 1][col], matrix[row - 1][col - 1], matrix[row][col - 1]) + 1

print('Minimum Edit Distance at String one= '+str(matrix[len(str2)][len(str1)]))
