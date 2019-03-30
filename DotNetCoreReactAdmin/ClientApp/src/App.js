import React from 'react';
import { Admin, Resource } from 'react-admin';
import simpleRestProvider from 'ra-data-simple-rest'
import UserIcon from '@material-ui/icons/Group';
import Dashboard from './Dashboard';
import { UserList, UserEdit, UserCreate } from './Users'

const dataProvider = simpleRestProvider('/api');
const App = () => (
    <Admin  dashboard={Dashboard} dataProvider={dataProvider}>
        <Resource name="user" list={UserList} edit={UserEdit} create={UserCreate} icon={UserIcon} />
    </Admin>
);

export default App;
