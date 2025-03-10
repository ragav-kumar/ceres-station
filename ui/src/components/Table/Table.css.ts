import { globalStyle, style } from '@vanilla-extract/css';

export const tableStyle = style({
    margin: '1rem',
    borderCollapse: 'collapse',
    width: 'max-content',
    minWidth: '100%',
});

// Bottom border on heading row
globalStyle(`${tableStyle} thead th`, {
    borderBottom: '1px solid #ddd',
    padding: '0 .5rem;',
});

// Space between head and body
globalStyle(`${tableStyle} tbody:before`, {
    content: '@',
    display: 'block',
    lineHeight: .5,
    textIndent: -99999,
});

globalStyle(`${tableStyle} th, ${tableStyle} td`, {

});

export const cellStyle = style({
    textAlign: 'center',
    textOverflow: 'ellipsis',
    height: '1em',
});

export const rowStyle = style({
    height: 'auto',
    whiteSpace: 'nowrap',
});

export const tableWrapperStyle = style({
    width: '100%',
    height: '100%',
    overflow: 'auto',
});