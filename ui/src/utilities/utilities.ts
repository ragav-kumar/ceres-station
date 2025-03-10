export const joinClassNames = (...classNames: (string | null | undefined)[]): string =>
    classNames
        .filter(c => c != null && c.trim().length > 0)
        .join(' ');