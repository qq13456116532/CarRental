
file_names = ['Confirm.razor', 'Confirm.razor.css', 'AddressBlock.razor', 'OrderItem.razor']
output_file = 'merged_output.txt'

with open(output_file, 'w', encoding='utf-8') as outfile:
    for file_name in file_names:
        try:
            with open(file_name, 'r', encoding='utf-8') as infile:
                content = infile.read()
                outfile.write(f'{file_name}:\n')
                outfile.write('【' + content.strip() + '】\n\n')
        except FileNotFoundError:
            outfile.write(f'{file_name}:\n【文件未找到】\n\n')

print(f"所有内容已合并到 {output_file}")
