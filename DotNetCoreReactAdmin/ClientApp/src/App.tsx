import { Admin, Resource } from "react-admin";
import UserIcon from "@mui/icons-material/Group";
import { Layout } from "./Layout";
import { dataProvider } from "./dataProvider";
import { UserList, UserEdit, UserCreate } from "./users";

import Dashboard from "./Dashboard";

export const App = () => (
  <Admin layout={Layout} dataProvider={dataProvider} dashboard={Dashboard}>
    <Resource
      name="user"
      icon={UserIcon}
      list={UserList}
      edit={UserEdit}
      create={UserCreate}
    />
  </Admin>
);
