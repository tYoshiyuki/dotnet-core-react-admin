import {
  Datagrid,
  EmailField,
  List,
  TextField,
  NumberField,
  Edit,
  SimpleForm,
  TextInput,
  NumberInput,
  Create,
  EditButton,
} from "react-admin";

const userFilter = [
  // eslint-disable-next-line react/jsx-key
  <TextInput label="Name" source="Name" />,
  // eslint-disable-next-line react/jsx-key
  <NumberInput label="Age" source="Age" />,
  // eslint-disable-next-line react/jsx-key
  <TextInput label="Email" source="Email" />,
];

export const UserList = () => (
  <List filters={userFilter} sort={{ field: "id", order: "ASC" }}>
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

export const UserEdit = () => (
  <Edit>
    <SimpleForm>
      <TextInput source="name" />
      <NumberInput source="age" />
      <TextInput source="email" />
      <TextInput source="phone" />
      <TextInput source="website" />
    </SimpleForm>
  </Edit>
);

export const UserCreate = () => (
  <Create>
    <SimpleForm>
      <TextInput source="name" />
      <NumberInput source="age" />
      <TextInput source="email" />
      <TextInput source="phone" />
      <TextInput source="website" />
    </SimpleForm>
  </Create>
);
