(function webpackUniversalModuleDefinition(root, factory) {
	if(typeof exports === 'object' && typeof module === 'object')
		module.exports = factory(require("vue"));
	else if(typeof define === 'function' && define.amd)
		define([], factory);
	else if(typeof exports === 'object')
		exports["curdLightBox"] = factory(require("vue"));
	else
		root["curdLightBox"] = factory(root["Vue"]);
})((typeof self !== 'undefined' ? self : this), (__WEBPACK_EXTERNAL_MODULE__203__) => {
return /******/ (() => { // webpackBootstrap
/******/ 	"use strict";
/******/ 	var __webpack_modules__ = ({

/***/ 514:
/***/ ((__unused_webpack_module, exports) => {

var __webpack_unused_export__;

__webpack_unused_export__ = ({ value: true });
// runtime helper for setting properties on components
// in a tree-shakable way
exports.Z = (sfc, props) => {
    const target = sfc.__vccOpts || sfc;
    for (const [key, val] of props) {
        target[key] = val;
    }
    return target;
};


/***/ }),

/***/ 203:
/***/ ((module) => {

module.exports = __WEBPACK_EXTERNAL_MODULE__203__;

/***/ })

/******/ 	});
/************************************************************************/
/******/ 	// The module cache
/******/ 	var __webpack_module_cache__ = {};
/******/ 	
/******/ 	// The require function
/******/ 	function __webpack_require__(moduleId) {
/******/ 		// Check if module is in cache
/******/ 		var cachedModule = __webpack_module_cache__[moduleId];
/******/ 		if (cachedModule !== undefined) {
/******/ 			return cachedModule.exports;
/******/ 		}
/******/ 		// Create a new module (and put it into the cache)
/******/ 		var module = __webpack_module_cache__[moduleId] = {
/******/ 			// no module.id needed
/******/ 			// no module.loaded needed
/******/ 			exports: {}
/******/ 		};
/******/ 	
/******/ 		// Execute the module function
/******/ 		__webpack_modules__[moduleId](module, module.exports, __webpack_require__);
/******/ 	
/******/ 		// Return the exports of the module
/******/ 		return module.exports;
/******/ 	}
/******/ 	
/************************************************************************/
/******/ 	/* webpack/runtime/define property getters */
/******/ 	(() => {
/******/ 		// define getter functions for harmony exports
/******/ 		__webpack_require__.d = (exports, definition) => {
/******/ 			for(var key in definition) {
/******/ 				if(__webpack_require__.o(definition, key) && !__webpack_require__.o(exports, key)) {
/******/ 					Object.defineProperty(exports, key, { enumerable: true, get: definition[key] });
/******/ 				}
/******/ 			}
/******/ 		};
/******/ 	})();
/******/ 	
/******/ 	/* webpack/runtime/hasOwnProperty shorthand */
/******/ 	(() => {
/******/ 		__webpack_require__.o = (obj, prop) => (Object.prototype.hasOwnProperty.call(obj, prop))
/******/ 	})();
/******/ 	
/******/ 	/* webpack/runtime/publicPath */
/******/ 	(() => {
/******/ 		__webpack_require__.p = "";
/******/ 	})();
/******/ 	
/************************************************************************/
var __webpack_exports__ = {};
// This entry need to be wrapped in an IIFE because it need to be isolated against other modules in the chunk.
(() => {

// EXPORTS
__webpack_require__.d(__webpack_exports__, {
  "default": () => (/* binding */ D_Programs_Develope_nvm_v16_14_1_node_modules_vue_cli_service_lib_commands_build_entry_lib)
});

;// CONCATENATED MODULE: D:\Programs\Develope\nvm\v16.14.1\node_modules\@vue\cli-service\lib\commands\build\setPublicPath.js
/* eslint-disable no-var */
// This file is imported into lib/wc client bundles.

if (typeof window !== 'undefined') {
  var currentScript = window.document.currentScript
  if (false) { var getCurrentScript; }

  var src = currentScript && currentScript.src.match(/(.+\/)[^/]+\.js(\?.*)?$/)
  if (src) {
    __webpack_require__.p = src[1] // eslint-disable-line
  }
}

// Indicate to webpack that this file can be concatenated
/* harmony default export */ const D_Programs_Develope_nvm_v16_14_1_node_modules_vue_cli_service_lib_commands_build_setPublicPath = (null);

// EXTERNAL MODULE: external {"commonjs":"vue","commonjs2":"vue","root":"Vue"}
var external_commonjs_vue_commonjs2_vue_root_Vue_ = __webpack_require__(203);
;// CONCATENATED MODULE: D:\Programs\Develope\nvm\v16.14.1\node_modules\@vue\cli-service\node_modules\vue-loader\dist\templateLoader.js??ruleSet[1].rules[2]!D:\Programs\Develope\nvm\v16.14.1\node_modules\@vue\cli-service\node_modules\vue-loader\dist\index.js??ruleSet[0].use[0]!./curdLightBox.vue?vue&type=template&id=4c4b419f


const _hoisted_1 = { class: "lightbox" }
const _hoisted_2 = { class: "modal-body" }
const _hoisted_3 = /*#__PURE__*/(0,external_commonjs_vue_commonjs2_vue_root_Vue_.createTextVNode)("Default Header")
const _hoisted_4 = /*#__PURE__*/(0,external_commonjs_vue_commonjs2_vue_root_Vue_.createElementVNode)("hr", null, null, -1)
const _hoisted_5 = /*#__PURE__*/(0,external_commonjs_vue_commonjs2_vue_root_Vue_.createTextVNode)("Default Body")
const _hoisted_6 = /*#__PURE__*/(0,external_commonjs_vue_commonjs2_vue_root_Vue_.createElementVNode)("hr", null, null, -1)
const _hoisted_7 = /*#__PURE__*/(0,external_commonjs_vue_commonjs2_vue_root_Vue_.createTextVNode)("Default Footer")

function render(_ctx, _cache, $props, $setup, $data, $options) {
  return ((0,external_commonjs_vue_commonjs2_vue_root_Vue_.openBlock)(), (0,external_commonjs_vue_commonjs2_vue_root_Vue_.createElementBlock)("div", _hoisted_1, [
    ((0,external_commonjs_vue_commonjs2_vue_root_Vue_.openBlock)(), (0,external_commonjs_vue_commonjs2_vue_root_Vue_.createBlock)(external_commonjs_vue_commonjs2_vue_root_Vue_.Teleport, { to: "body" }, [
      (0,external_commonjs_vue_commonjs2_vue_root_Vue_.createElementVNode)("div", {
        class: "modal-mask",
        style: (0,external_commonjs_vue_commonjs2_vue_root_Vue_.normalizeStyle)($setup.modalStyle)
      }, [
        (0,external_commonjs_vue_commonjs2_vue_root_Vue_.createElementVNode)("div", {
          class: "modal-container",
          onClick: _cache[0] || (_cache[0] = (0,external_commonjs_vue_commonjs2_vue_root_Vue_.withModifiers)((...args) => ($setup.toggleModal && $setup.toggleModal(...args)), ["self"]))
        }, [
          (0,external_commonjs_vue_commonjs2_vue_root_Vue_.createElementVNode)("div", _hoisted_2, [
            (0,external_commonjs_vue_commonjs2_vue_root_Vue_.createElementVNode)("header", null, [
              (0,external_commonjs_vue_commonjs2_vue_root_Vue_.renderSlot)(_ctx.$slots, "header", {}, () => [
                _hoisted_3
              ])
            ]),
            _hoisted_4,
            (0,external_commonjs_vue_commonjs2_vue_root_Vue_.createElementVNode)("main", null, [
              (0,external_commonjs_vue_commonjs2_vue_root_Vue_.renderSlot)(_ctx.$slots, "default", {}, () => [
                _hoisted_5
              ])
            ]),
            _hoisted_6,
            (0,external_commonjs_vue_commonjs2_vue_root_Vue_.createElementVNode)("footer", null, [
              (0,external_commonjs_vue_commonjs2_vue_root_Vue_.renderSlot)(_ctx.$slots, "footer", {}, () => [
                _hoisted_7
              ])
            ])
          ])
        ])
      ], 4)
    ]))
  ]))
}
;// CONCATENATED MODULE: ./curdLightBox.vue?vue&type=template&id=4c4b419f

;// CONCATENATED MODULE: D:\Programs\Develope\nvm\v16.14.1\node_modules\@vue\cli-service\node_modules\vue-loader\dist\index.js??ruleSet[0].use[0]!./curdLightBox.vue?vue&type=script&lang=js

//import { ref, watch, computed } from "/vue/vue.esm-browser.js"

/* harmony default export */ const D_Programs_Develope_nvm_v16_14_1_node_modules_vue_cli_service_node_modules_vue_loader_dist_index_ruleSet_0_use_0_curdLightBoxvue_type_script_lang_js = ({
  name:"curdLightBox",
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
            emit('lightbox-Close', false);
        }

        return {
            isShow,
            modalStyle,
            toggleModal,
            addRecord
        }
    }
});

;// CONCATENATED MODULE: ./curdLightBox.vue?vue&type=script&lang=js
 
// EXTERNAL MODULE: D:\Programs\Develope\nvm\v16.14.1\node_modules\@vue\cli-service\node_modules\vue-loader\dist\exportHelper.js
var D_Programs_Develope_nvm_v16_14_1_node_modules_vue_cli_service_node_modules_vue_loader_dist_exportHelper = __webpack_require__(514);
;// CONCATENATED MODULE: ./curdLightBox.vue




;
const __exports__ = /*#__PURE__*/(0,D_Programs_Develope_nvm_v16_14_1_node_modules_vue_cli_service_node_modules_vue_loader_dist_exportHelper/* default */.Z)(D_Programs_Develope_nvm_v16_14_1_node_modules_vue_cli_service_node_modules_vue_loader_dist_index_ruleSet_0_use_0_curdLightBoxvue_type_script_lang_js, [['render',render]])

/* harmony default export */ const curdLightBox = (__exports__);
;// CONCATENATED MODULE: D:\Programs\Develope\nvm\v16.14.1\node_modules\@vue\cli-service\lib\commands\build\entry-lib.js


/* harmony default export */ const D_Programs_Develope_nvm_v16_14_1_node_modules_vue_cli_service_lib_commands_build_entry_lib = (curdLightBox);


})();

__webpack_exports__ = __webpack_exports__["default"];
/******/ 	return __webpack_exports__;
/******/ })()
;
});
//# sourceMappingURL=curdLightBox.umd.js.map