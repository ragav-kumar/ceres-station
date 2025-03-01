import { Table } from 'components/Table';
import styles from './App.module.css';
import { Api, EntityType, ExtractorDto } from './api';

export const App = () => (
    <div className={styles.wrap}>
        <Table<ExtractorDto>
            fetchData={Api.Extractors.Get}
            fetchColumns={() => Api.Columns.Get(EntityType.Extractor)}
        />
    </div>
);