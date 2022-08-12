import { useState, useEffect } from 'react';
import API from '../API';
const useTodoApi = () => {
   const [ loading, setLoading ] = useState(false);
   const [ error, setError ] = useState(false);
   const [ todos, setTodos ] = useState([]);

   useEffect(() => {
      const getData = async () => {
         setLoading(true);
         const data = await API.getAll();
         setTodos(data);
         setLoading(false);
      };
      getData();
   }, []);

   return { loading, error, todos, setTodos };
};

export default useTodoApi;
