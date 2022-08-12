import React, { useState } from 'react';
import API from '../API';
import '../custom.css';

function Todo({ id, text, isCompleted, setTodos }){
   const [ isEditing, setIsEditing ] = useState(false);
   const [ newText, setNewText ] = useState(text);
   const [ inputError, setInputError ] = useState(false);

   const toggleEdit = () => {
      setIsEditing((x) => !x);
   };

   const editTodo = async (id, newText, isCompleted) => {
      if (!newText) {
         setInputError(true);
         setTimeout(() => {
            setInputError(false);
         }, 1500);
         return;
      }
      API.edit(id, newText, isCompleted);
      setTodos((x) => x.map((x) => (x.id !== id ? x : { ...x, text: newText, isCompleted: isCompleted })));
      toggleEdit();
   };

   const deleteTodo = async (id) => {
      API.delete(id);
      setTodos((x) => x.filter((x) => x.id !== id));
   };

   const handleComplete = async () => {
      setTodos((x) => x.map((x) => (x.id !== id ? x : (x = { ...x, isCompleted: !isCompleted }))));
      editTodo(id, newText, !isCompleted);
   };

   return isEditing ? (
      <React.Fragment>
         <div className='todo'>
            <input type={'text'} value={newText} onChange={(e) => setNewText(e.target.value)} />
            <div className='todo-options'>
               <button
                  onClick={() => {
                     editTodo(id, newText, isCompleted);
                  }}
               >
                  Save changes
               </button>
               <button
                  onClick={() => {
                     toggleEdit();
                     setNewText(text);
                  }}
               >
                  Cancel
               </button>
            </div>
         </div>
         <h3 className={`error-msg ${!inputError ? 'hidden' : ''}`}>Input field cannot be empty</h3>
      </React.Fragment>
   ) : (
      <div className='todo'>
         <h2 onClick={handleComplete} className={isCompleted ? 'complete' : ''}>
            {text}
         </h2>
         <div className='todo-options'>
            <button onClick={() => deleteTodo(id)}>Delete</button>
            <button onClick={toggleEdit}>Edit</button>
         </div>
      </div>
   );
}

export default Todo;
