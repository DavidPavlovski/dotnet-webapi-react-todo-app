import React, { useState } from 'react';
import Todo from './Todo';
import API from '../API';
import useTodoApi from '../hooks/useTodoApi';
import Spinner from './Spinner';
function TodoList(){
   const { loading, todos, setTodos } = useTodoApi();
   const [ newTodo, setNewTodo ] = useState('');
   const [ inputError, setInputError ] = useState(false);

   const createTodo = async (e, todoText) => {
      e.preventDefault();
      if (!newTodo) {
         setInputError(true);
         setTimeout(() => {
            setInputError(false);
         }, 1500);
         return;
      }
      setNewTodo('');
      var id = await API.create(todoText);
      setTodos((x) => [ ...x, { id: id, text: todoText, isCompleted: false } ]);
   };

   if (loading) {
      return <Spinner />;
   }
   return (
      <div className='todo-container'>
         <h1>TodoList App</h1>
         <div className='todolist-container'>
            {todos.map((x) => (
               <Todo key={x.id} id={x.id} text={x.text} isCompleted={x.isCompleted} setTodos={setTodos} />
            ))}
         </div>
         <form
            className='new-todo-form'
            action='/api/todo/create'
            method='POST'
            onSubmit={(e) => createTodo(e, newTodo)}
         >
            <input
               type={'text'}
               value={newTodo}
               onChange={(e) => setNewTodo(e.target.value)}
               placeholder='new todo text'
            />
            <h3 className={`error-msg ${!inputError ? 'hidden' : ''}`}>Input field cannot be empty</h3>
            <button type='submit'>Create new Todo</button>
         </form>
      </div>
   );
}

export default TodoList;
