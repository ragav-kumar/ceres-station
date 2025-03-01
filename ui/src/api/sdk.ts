import { ColumnDto, EntityType, ExtractorDto } from './dto.ts';

/**
 * A generic GET method for fetching data from an API.
 *
 * @template T The expected data type for the returned response.
 * @param endpoint The endpoint URL to fetch data from.
 * @returns Promise resolving to the data of type T.
 */
const fetchData = async <T>(endpoint: string): Promise<T> => {
    try {
        const response = await fetch(`/api/${endpoint}`, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
            },
        });

        if (!response.ok) {
            return Promise.reject(response.statusText);
        }

        return await response.json();
    } catch (error) {
        console.error(`Failed to fetch data from /api/${endpoint}:`, error);
        throw error;
    }
};


export const Api = {
    Extractors: {
        Get: () => fetchData<ExtractorDto[]>('extractors'),
        GetOne: (id: string) => fetchData<ExtractorDto>(`extractors/${id}`),
    },
    Columns: {
        Get: (entityType: EntityType) => {
            const entityTypeStr = entityType.toString();
            return fetchData<ColumnDto[]>(`columns/${entityTypeStr}`);
        },
    },
};