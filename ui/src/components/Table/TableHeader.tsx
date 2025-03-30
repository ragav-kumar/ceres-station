import { ColumnDto } from 'api/dto';
import { HeaderCell } from './HeaderCell';

interface HeaderRowProps {
    columns: ColumnDto[];
}

export const TableHeader = ({columns}: HeaderRowProps) => (
    <thead>
    <tr>
        {columns.map((column, index) => (
            <HeaderCell key={index} column={column}/>
        ))}
    </tr>
    </thead>
);