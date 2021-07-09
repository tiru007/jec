<template>
   <div>        
     <div>
       <add-customer />
       <displaycustomers />
     </div>
     
  </div>
</template>

<script>
import addCustomer from './addCustomer.vue'
import displaycustomers from './displaycustomers.vue'
  export default {
    name: "App",
    components: {addCustomer, displaycustomers}
  
}
</script>
