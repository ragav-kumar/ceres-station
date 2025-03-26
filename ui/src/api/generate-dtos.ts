import { readFileSync, writeFileSync } from 'node:fs';
import {
    createSourceFile,
    forEachChild,
    isInterfaceDeclaration,
    isPropertySignature, isTypeLiteralNode,
    PropertySignature,
    ScriptTarget
} from 'typescript';

const sourceFile = createSourceFile(
    'src/api/schema.d.ts',
    readFileSync('src/api/schema.d.ts', 'utf8'),
    ScriptTarget.Latest,
    true
);

const typeNames: string[] = [];

// Only want to look in components['schemas']
forEachChild(sourceFile, node => {
    if (
        isInterfaceDeclaration(node) &&
        node.name.text === 'components'
    ) {
        const schemas = node.members.find(m =>
            isPropertySignature(m) &&
            m.name.getText() === 'schemas'
        ) as PropertySignature;

        if (schemas?.type && isTypeLiteralNode(schemas.type)) {
            schemas.type.members.forEach(member => {
                if (isPropertySignature(member)) {
                    const name = member.name.getText().replace(/['"]/g, '');
                    typeNames.push(name);
                }
            });
        }
    }
});


const output =
`/**
 * This file is auto-generated via 'generate-dtos.ts'.
 * Do not edit manually.
 */

import type { components } from './schema';

${typeNames
    .map(typeName => `export type ${typeName} = components['schemas']['${typeName}']`)
    .join('\n')
}
`;

writeFileSync('src/api/dto.ts', output);