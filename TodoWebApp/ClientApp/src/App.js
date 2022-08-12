import React from 'react';
import './custom.css';
import { NavMenu } from './components/NavMenu';
import TodoList from './components/TodoList';
function App(){
   return (
      <React.Fragment>
         <NavMenu />
         <TodoList />
      </React.Fragment>
   );
}

export default App;
