import React from 'react';
import { Datagrid, EmailField, List, TextField, NumberField, Edit, SimpleForm, TextInput, NumberInput, Create, EditButton, Filter } from 'react-admin';

const UserFilter = (props) => (
    <Filter {...props}>
        <TextInput label="Name" source="Name" />
        <NumberInput label="Age" source="Age" />
        <TextInput label="Email" source="Email" />
    </Filter>
);

export const UserList = props => (
    <List {...props} filters={<UserFilter />}>
        <Datagrid>
            <TextField source="id" />
            <TextField source="name" />
            <NumberField source="age" />
            <EmailField source="email" />
            <TextField source="phone" />
            <TextField source="website" />
            <EditButton />
        </Datagrid>
    </List>
);

export const UserEdit = props => (
    <Edit {...props}>
        <SimpleForm>
            <TextInput source="name" />
            <NumberInput source="age" />
            <TextInput source="email" />
            <TextInput source="phone" />
            <TextInput source="website" />
        </SimpleForm>
    </Edit>
);

export const UserCreate = props => (
    <Create {...props}>
        <SimpleForm>
            <TextInput source="name" />
            <NumberInput source="age" />
            <TextInput source="email" />
            <TextInput source="phone" />
            <TextInput source="website" />
        </SimpleForm>
    </Create>
);
