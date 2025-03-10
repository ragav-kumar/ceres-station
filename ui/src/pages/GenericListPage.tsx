import { useTitle } from 'entry/TitleContext';
import { Table } from 'components/Table';

interface GenericListPageProps {
    entity: string;
    pageTitle?: string;
}

export const GenericListPage = ({entity, pageTitle}: GenericListPageProps) => {
    useTitle(pageTitle ?? entity);

    return (
        <Table entity={entity} />
    );
};