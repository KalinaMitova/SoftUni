function solve(text, delimeter) {
    return text.split(delimeter).join("\n");
}

solve('One-Two-Three-Four-Five', '-');