import * as React from 'react';
import UserIcon from '@mui/icons-material/Group';
import {Admin, Resource} from 'react-admin';
import simpleRestProvider from 'ra-data-simple-rest';
import {UserList, UserEdit, UserCreate} from './Users'

import Dashboard from './Dashboard';

const dataProvider = simpleRestProvider('/api');
const App = () => (
    <Admin dataProvider={dataProvider} dashboard={Dashboard}>
        <Resource name="user" icon={UserIcon} list={UserList} edit={UserEdit} create={UserCreate}/>
    </Admin>
);
export default App;
