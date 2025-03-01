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
    Id: string;
    EntityType: EntityType;
    DisplayName?: string;
    AttributeDefinitionId?: string;
    FieldName?: string;
    Width?: number;
    Order: number;
}