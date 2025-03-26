import { EntityDto } from 'api/dto.ts';

export const joinClassNames = (...classNames: (string | null | undefined)[]): string =>
    classNames
        .filter(c => c != null && c.trim().length > 0)
        .join(' ');

export const isEntityDto = (obj: unknown): obj is EntityDto => (
    obj != null &&
    typeof obj === 'object' &&
    Object.hasOwn(obj, 'name') && (obj as Record<string, unknown>).name != null &&
    Object.hasOwn(obj, 'id') && (obj as Record<string, unknown>).id != null &&
    Object.hasOwn(obj, 'position') && (obj as Record<string, unknown>).position != null
);