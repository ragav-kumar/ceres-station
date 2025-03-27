import { EntityDto, ResourceDto } from 'api/dto.ts';
import { isValidElement, ReactNode } from 'react';

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

export const isResourceDto = (obj: unknown): obj is ResourceDto => (
    obj != null &&
    typeof obj === 'object' &&
    Object.hasOwn(obj, 'name') &&
    Object.hasOwn(obj, 'id') && (obj as Record<string, unknown>).id != null
);

export const isReactNode = ( value: unknown): value is ReactNode => {
    if (value == null || typeof value === 'boolean') {
        return true;
    }
    if (typeof value === 'string' || typeof value === 'number') {
        return true;
    }
    if (isValidElement(value)) {
        return true;
    }
    if (Array.isArray(value)) {
        return value.every(isReactNode);
    }
    return false;
};