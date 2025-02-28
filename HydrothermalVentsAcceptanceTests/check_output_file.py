import sys

def read_file(filepath):
    """Reads a file and returns a set of its lines, ignoring empty lines and trimming whitespace."""
    try:
        with open(filepath, 'r', encoding='utf-8') as file:
            return set(line.strip() for line in file if line.strip())
    except FileNotFoundError:
        return None

def compare_files(file1, file2):
    """Compares two files and returns True if they contain the same lines, regardless of order."""

    content1 = read_file(file1)
    content2 = read_file(file2)
    
    if content1 is None or content2 is None:
        return False
    # sort file content and compare

    return sorted(content1) == sorted(content2)

if __name__ == "__main__":
    if len(sys.argv) != 3:
        sys.exit(1)
    
    file1, file2 = sys.argv[1], sys.argv[2]
    result = compare_files(file1, file2)

    if not result:
        print("The files are different.")
        print(f"Contents of {file1}:")
        with open(file1, 'r', encoding='utf-8') as f:
            print(f.read())
        print(f"Contents of {file2}:")
        with open(file2, 'r', encoding='utf-8') as f:
            print(f.read())
    
    sys.exit(0 if result else 1)
