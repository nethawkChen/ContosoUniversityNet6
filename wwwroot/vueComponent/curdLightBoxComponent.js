import { ref, watch, computed } from "/vue/vue.esm-browser.js"

const curdLightBoxComponent = {
    props: {
        isdisplay: {          //接收外層傳入的旗標值(true:顯示, false:隱藏)
            type: Boolean,
            default: false
        }
    },
    setup(props, { emit }) {
        const isShow = ref(false);

        //監控 props.isdisply 的值有沒有變化來異動元件內的 isShow 的值
        watch(() => props.isdisplay, (newVal) => {
            isShow.value = newVal;
        })
        //用來顯示或隱藏 lightbox
        let modalStyle = computed(() => {
            return {
                'display': isShow.value ? '' : 'none'
            };
        })

        function toggleModal() {
            isShow.value = !isShow.value;
            closeDialog();
        };

        //t
        function addRecord() {
            console.log('元件中 addRecord 被觸發');
            emit('add-Record')
        }

        //關閉 lightbox 並回傳 lightbox 開關值給上層元件
        const closeDialog = () => {
            console.log('元件中 lcoseDialog 被觸發');
            emit('lightbox-Close', false);
        }

        return {
            isShow,
            modalStyle,
            toggleModal,
            //addRecord
        }
    },
    template: `
            <div class="lightbox">
                <teleport to="body">
                    <div class="modal-mask" v-bind:style="modalStyle">
                        <div class="modal-container" v-on:click.self="toggleModal">
                            <div class="modal-body">
                                <header>
                                    <slot name="header">Default Header</slot>
                                </header>
                                <hr>
                                <main>
                                    <slot>Default Body</slot>
                                </main>
                                <hr>
                                <footer>
                                    <slot name="footer">Default Footer</slot>
                                </footer>
                            </div>
                        </div>
                    </div>
                </teleport>
            </div>`
}

export default curdLightBoxComponent