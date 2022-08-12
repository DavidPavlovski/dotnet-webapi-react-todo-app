const API = {
   getAll: async function(){
      const res = await fetch('api/todo/getall');
      const data = await res.json();
      return data;
   },
   create: async function(text){
      const requestOptions = {
         method: 'POST',
         headers: {
            'Content-Type': 'application/json'
         },
         body: JSON.stringify({ text })
      };
      const res = await fetch('api/todo/create', requestOptions);
      const data = res.json();
      return data;
   },
   edit: async function(id, text, isCompleted){
      const res = await fetch(`/api/todo/edit/id/${id}`, {
         method: 'PUT',
         headers: {
            'Content-Type': 'application/json'
         },
         body: JSON.stringify({ text: text, isCompleted: isCompleted })
      });
      const data = await res.json();
   },
   delete: async function(id){
      const requestOptions = {
         method: 'DELETE',
         headers: {
            'Content-Type': 'application/json'
         }
      };
      const res = await fetch(`api/todo/delete/id/${id}`, requestOptions);
      const data = await res.json();
   }
};

export default API;
