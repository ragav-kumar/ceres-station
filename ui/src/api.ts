import createFetchClient from 'openapi-fetch';
import createClient from 'openapi-react-query';
import type { paths } from './schema';

const fetchClient = createFetchClient<paths>({
    baseUrl: 'http://localhost:5000',
});

const api = createClient(fetchClient);

export const useQuery = api.useQuery;