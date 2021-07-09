<template>
  <div>
    <b-table small :fields="fields" :items="items" responsive="sm">
      <!-- A virtual column -->
      <template #cell(index)="data">
        {{ data.index + 1 }}
      </template>

      <!-- A custom formatted column -->
      <template #cell(fullname)="data">
        <b class="text-info">{{ data.item.value.email }}</b>, <b class="text-info">{{ data.item.value.mobilenumber }}</b>, <b class="text-info">{{ data.item.value.name }}</b>
      </template>

    </b-table>
    </div>
</template>

<script>
import axios from 'axios'
export default {
        data() {      
                    return {
                            fields: [
                                // A virtual column that doesn't exist in items
                                'index',
                                'name',
                                // A column that needs custom formatting
                            'email',
                                // A regular column
                                'mobilenumber'
                            ],
                            items: []
            }
            },
            mounted () {
            axios
            .get('https://lively-wave-051b7f910.azurestaticapps.net/api/getcustomers')
            .then(response => (this.items = response.data, console.warn(response.data)))
        }
}
</script>

<style>

</style>