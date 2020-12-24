let profile = new Vue({
    el: '#profileId',
    data: {
        selectedMenuItem: {},
        selectedId:"",
        profileMenuList: []
    },
    created: function () {
        this.profileMenuList=FULL_PROFILE_MENU
    },
    computed: {
        filteredList() {
            return this.profileMenuList;
        },
        component() {
            if (this.selectedMenuItem && this.selectedMenuItem.component) {
                if (Vue.options.components[this.selectedMenuItem.component]) {
                    return this.selectedMenuItem.component;
                }
            }
            return '';
        },
    },
    
    methods: {
        isSelected(id) {
            return this.selectedId === id;
        },
        setSelected(menuItem) {
            this.selectedMenuItem = menuItem;
            this.selectedId = menuItem.id;
        },
        
    }
})