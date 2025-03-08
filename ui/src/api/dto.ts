export interface ExtractorDto {
    Id: string;
    Name: string;
    ExtractionRate: number;
    StandardDeviation: number;
    Stockpile: number;
    Capacity: number;
    Resource: ResourceDto;
}

export interface ResourceDto {
    Id: string;
    Name: string;
}

export enum EntityType {
    Undefined = 0,
    Extractor = 1,
    Processor = 2,
    Transport = 3,
    Consumer = 4,
}

export interface ColumnDto {
    id: string;
    entityType: EntityType;
    displayName?: string;
    attributeDefinitionId?: string;
    fieldName?: string;
    width?: number;
    order: number;
}

export interface ListRowDto {
    [key: string]: unknown;
}

export interface ListDataDto {
    rows: ListRowDto[];
    totalCount: number;
}