"use strict";(self.webpackChunkloadgistix=self.webpackChunkloadgistix||[]).push([[727],{1638:(O,M,f)=>{f.d(M,{S:()=>J});var h=f(8407);function l(){return(l=Object.assign||function(r){for(var o=1;o<arguments.length;o++){var n=arguments[o];for(var t in n)Object.prototype.hasOwnProperty.call(n,t)&&(r[t]=n[t])}return r}).apply(this,arguments)}function i(r,o){r.prototype=Object.create(o.prototype),r.prototype.constructor=r,r.__proto__=o}function g(r,o){return(g=Object.setPrototypeOf||function(n,t){return n.__proto__=t,n})(r,o)}function E(){if("undefined"==typeof Reflect||!Reflect.construct||Reflect.construct.sham)return!1;if("function"==typeof Proxy)return!0;try{return Date.prototype.toString.call(Reflect.construct(Date,[],function(){})),!0}catch(r){return!1}}function T(r,o,n){return(T=E()?Reflect.construct:function(t,e,a){var s=[null];s.push.apply(s,e);var c=new(Function.bind.apply(t,s));return a&&g(c,a.prototype),c}).apply(null,arguments)}function v(r,o,n,t){void 0===o&&(o=""),void 0===t&&(t={});var e=document.createElement(r);return o&&(e.className=o),Object.keys(t).forEach(function(a){if("function"==typeof t[a]){var s=0===a.indexOf("on")?a.substr(2).toLowerCase():a;e.addEventListener(s,t[a])}else"html"===a?e.innerHTML=t[a]:"text"===a?e.innerText=t[a]:e.setAttribute(a,t[a])}),n&&n.appendChild(e),e}function k(r){r.preventDefault(),r.stopPropagation()}var L=function(){for(var r=arguments.length,o=new Array(r),n=0;n<r;n++)o[n]=arguments[n];return o.filter(Boolean).join(" ").trim()};function x(r,o){r&&r.classList&&(Array.isArray(o)?o:[o]).forEach(function(n){r.classList.contains(n)||r.classList.add(n)})}function b(r,o){r&&r.classList&&(Array.isArray(o)?o:[o]).forEach(function(n){r.classList.contains(n)&&r.classList.remove(n)})}var w,r,p=13,y=40,u=38,P=[p,27,y,u,37,39],A=function(){function r(n){var t=this,e=n.handleSubmit,a=n.searchLabel,s=n.classNames,c=void 0===s?{}:s;this.hasError=!1,this.container=v("div",L("geosearch",c.container)),this.form=v("form",["",c.form].join(" "),this.container,{autocomplete:"none",onClick:k,onDblClick:k,touchStart:k,touchEnd:k}),this.input=v("input",["glass",c.input].join(" "),this.form,{type:"text",placeholder:a||"search",onInput:this.onInput,onKeyUp:function(m){return t.onKeyUp(m)},onKeyPress:function(m){return t.onKeyPress(m)},onFocus:this.onFocus,onBlur:this.onBlur,onClick:function(){t.input.focus(),t.input.dispatchEvent(new Event("focus"))}}),this.handleSubmit=e}var o=r.prototype;return o.onFocus=function(){x(this.form,"active")},o.onBlur=function(){b(this.form,"active")},o.onSubmit=function(n){try{var t=this;return k(n),b(e=t.container,"error"),x(e,"pending"),Promise.resolve(t.handleSubmit({query:t.input.value})).then(function(){b(t.container,"pending")})}catch(a){return Promise.reject(a)}var e},o.onInput=function(){this.hasError&&(b(this.container,"error"),this.hasError=!1)},o.onKeyUp=function(n){27===n.keyCode&&(b(this.container,["pending","active"]),this.input.value="",document.body.focus(),document.body.blur())},o.onKeyPress=function(n){n.keyCode===p&&this.onSubmit(n)},o.setQuery=function(n){this.input.value=n},r}(),D=function(){function r(n){var t=this,e=n.handleClick,a=n.classNames,s=void 0===a?{}:a,c=n.notFoundMessage;this.selected=-1,this.results=[],this.onClick=function(m){if("function"==typeof t.handleClick){var C=m.target;if(C&&t.container.contains(C)&&C.hasAttribute("data-key")){var U=Number(C.getAttribute("data-key"));t.clear(),t.handleClick({result:t.results[U]})}}},this.handleClick=e,this.notFoundMessage=c?v("div",L(s.notfound),void 0,{html:c}):void 0,this.container=v("div",L("results",s.resultlist)),this.container.addEventListener("click",this.onClick,!0),this.resultItem=v("div",L(s.item))}var o=r.prototype;return o.render=function(n,t){var e=this;void 0===n&&(n=[]),this.clear(),n.forEach(function(a,s){var c=e.resultItem.cloneNode(!0);c.setAttribute("data-key",""+s),c.innerHTML=t({result:a}),e.container.appendChild(c)}),n.length>0?(x(this.container.parentElement,"open"),x(this.container,"active")):this.notFoundMessage&&(this.container.appendChild(this.notFoundMessage),x(this.container.parentElement,"open")),this.results=n},o.select=function(n){return Array.from(this.container.children).forEach(function(t,e){return e===n?x(t,"active"):b(t,"active")}),this.selected=n,this.results[n]},o.count=function(){return this.results?this.results.length:0},o.clear=function(){for(this.selected=-1;this.container.lastChild;)this.container.removeChild(this.container.lastChild);b(this.container.parentElement,"open"),b(this.container,"active")},r}(),q={position:"topleft",style:"button",showMarker:!0,showPopup:!1,popupFormat:function(r){return""+r.result.label},resultFormat:function(r){return""+r.result.label},marker:{icon:h&&h.Icon?new h.Icon.Default:void 0,draggable:!1},maxMarkers:1,maxSuggestions:5,retainZoomLevel:!1,animateZoom:!0,searchLabel:"Enter address",notFoundMessage:"",messageHideDelay:3e3,zoomLevel:18,classNames:{container:"leaflet-bar leaflet-control leaflet-control-geosearch",button:"leaflet-bar-part leaflet-bar-part-single",resetButton:"reset",msgbox:"leaflet-bar message",form:"",input:"",resultlist:"",item:"",notfound:"leaflet-bar-notfound"},autoComplete:!0,autoCompleteDelay:250,autoClose:!1,keepResult:!1,updateMap:!0},N="Leaflet must be loaded before instantiating the GeoSearch control",F={options:l({},q),classNames:l({},q.classNames),initialize:function(r){var o,n,t,e,a=this;if(!h)throw new Error(N);if(!r.provider)throw new Error("Provider is missing from options");this.options=l({},this.options,{},r),this.classNames=l({},this.classNames,{},r.classNames),this.markers=new h.FeatureGroup,this.classNames.container+=" leaflet-geosearch-"+this.options.style,this.searchElement=new A({searchLabel:this.options.searchLabel,classNames:{container:this.classNames.container,form:this.classNames.form,input:this.classNames.input},handleSubmit:function(s){return a.onSubmit(s)}}),this.button=v("a",this.classNames.button,this.searchElement.container,{title:this.options.searchLabel,href:"#",onClick:function(s){return a.onClick(s)}}),h.DomEvent.disableClickPropagation(this.button),this.resetButton=v("a",this.classNames.resetButton,this.searchElement.form,{text:"\xd7",href:"#",onClick:function(){return a.clearResults(null,!0)}}),h.DomEvent.disableClickPropagation(this.resetButton),this.options.autoComplete&&(this.resultList=new D({handleClick:function(s){var c=s.result;a.searchElement.input.value=c.label,a.onSubmit({query:c.label,data:c})},classNames:{resultlist:this.classNames.resultlist,item:this.classNames.item,notfound:this.classNames.notfound},notFoundMessage:this.options.notFoundMessage}),this.searchElement.form.appendChild(this.resultList.container),this.searchElement.input.addEventListener("keyup",(o=function(s){return a.autoSearch(s)},void 0===(n=this.options.autoCompleteDelay)&&(n=250),void 0===t&&(t=!1),function(){for(var s=arguments.length,c=new Array(s),m=0;m<s;m++)c[m]=arguments[m];e&&clearTimeout(e),e=setTimeout(function(){e=null,t||o.apply(void 0,c)},n),t&&!e&&o.apply(void 0,c)}),!0),this.searchElement.input.addEventListener("keydown",function(s){return a.selectResult(s)},!0),this.searchElement.input.addEventListener("keydown",function(s){return a.clearResults(s,!0)},!0)),this.searchElement.form.addEventListener("click",function(s){s.preventDefault()},!1)},onAdd:function(r){var o=this.options,n=o.showMarker,t=o.style;if(this.map=r,n&&this.markers.addTo(r),"bar"===t){var e=r.getContainer().querySelector(".leaflet-control-container");this.container=v("div","leaflet-control-geosearch leaflet-geosearch-bar"),this.container.appendChild(this.searchElement.form),e.appendChild(this.container)}return h.DomEvent.disableClickPropagation(this.searchElement.form),this.searchElement.container},onRemove:function(){var r;return null==(r=this.container)||r.remove(),this},onClick:function(r){r.preventDefault(),r.stopPropagation();var o=this.searchElement,n=o.container,t=o.input;n.classList.contains("active")?(b(n,"active"),this.clearResults()):(x(n,"active"),t.focus())},selectResult:function(r){if(-1!==[p,y,u].indexOf(r.keyCode))if(r.preventDefault(),r.keyCode!==p){var o=this.resultList.count()-1;if(!(o<0)){var n=this.resultList.selected,t=r.keyCode===y?n+1:n-1,e=this.resultList.select(t<0?o:t>o?0:t);this.searchElement.input.value=e.label}}else{var a=this.resultList.select(this.resultList.selected);this.onSubmit({query:this.searchElement.input.value,data:a})}},clearResults:function(r,o){if(void 0===o&&(o=!1),!r||27===r.keyCode){var n=this.options,t=n.autoComplete;!o&&n.keepResult||(this.searchElement.input.value="",this.markers.clearLayers()),t&&this.resultList.clear()}},autoSearch:function(r){try{var o=this;if(P.indexOf(r.keyCode)>-1)return Promise.resolve();var n=r.target.value,t=o.options.provider,e=function(){if(n.length)return Promise.resolve(t.search({query:n})).then(function(a){a=a.slice(0,o.options.maxSuggestions),o.resultList.render(a,o.options.resultFormat)});o.resultList.clear()}();return Promise.resolve(e&&e.then?e.then(function(){}):void 0)}catch(a){return Promise.reject(a)}},onSubmit:function(r){try{var o=this;return Promise.resolve(o.options.provider.search(r)).then(function(n){n&&n.length>0&&o.showResult(n[0],r)})}catch(n){return Promise.reject(n)}},showResult:function(r,o){var n=this.options,t=n.autoClose,e=n.updateMap,a=this.markers.getLayers();a.length>=this.options.maxMarkers&&this.markers.removeLayer(a[0]);var s=this.addMarker(r,o);e&&this.centerMap(r),this.map.fireEvent("geosearch/showlocation",{location:r,marker:s}),t&&this.closeResults()},closeResults:function(){var r=this.searchElement.container;r.classList.contains("active")&&b(r,"active"),this.clearResults()},addMarker:function(r,o){var n=this,t=this.options,e=t.marker,a=t.showPopup,s=t.popupFormat,c=new h.Marker([r.y,r.x],e),m=r.label;return"function"==typeof s&&(m=s({query:o,result:r})),c.bindPopup(m),this.markers.addLayer(c),a&&c.openPopup(),e.draggable&&c.on("dragend",function(C){n.map.fireEvent("geosearch/marker/dragend",{location:c.getLatLng(),event:C})}),c},centerMap:function(r){var o=this.options,n=o.retainZoomLevel,t=o.animateZoom,e=r.bounds?new h.LatLngBounds(r.bounds):new h.LatLng(r.y,r.x).toBounds(10),a=e.isValid()?e:this.markers.getBounds();!n&&e.isValid()&&!r.bounds||n||!e.isValid()?this.map.setView(a.getCenter(),this.getZoom(),{animate:t}):this.map.fitBounds(a,{animate:t})},getZoom:function(){var r=this.options,o=r.zoomLevel;return r.retainZoomLevel?this.map.getZoom():o}};(r=w||(w={}))[r.SEARCH=0]="SEARCH",r[r.REVERSE=1]="REVERSE";var _=function(){function r(n){void 0===n&&(n={}),this.options=n}var o=r.prototype;return o.getParamString=function(n){void 0===n&&(n={});var t=l({},this.options.params,{},n);return Object.keys(t).map(function(e){return encodeURIComponent(e)+"="+encodeURIComponent(t[e])}).join("&")},o.getUrl=function(n,t){return n+"?"+this.getParamString(t)},o.search=function(n){try{var t=this,e=t.endpoint({query:n.query,type:w.SEARCH});return Promise.resolve(fetch(e)).then(function(a){return Promise.resolve(a.json()).then(function(s){return t.parse({data:s})})})}catch(a){return Promise.reject(a)}},r}(),W=(function(r){function o(){return r.apply(this,arguments)||this}i(o,r);var n=o.prototype;n.endpoint=function(){return"https://places-dsn.algolia.net/1/places/query"},n.findBestMatchLevelIndex=function(t){var e=t.find(function(a){return"full"===a.matchLevel})||t.find(function(a){return"partial"===a.matchLevel});return e?t.indexOf(e):0},n.getLabel=function(t){var e,a,s,c;return[null==(e=t.locale_names)?void 0:e.default[this.findBestMatchLevelIndex(t._highlightResult.locale_names.default)],null==(a=t.city)?void 0:a.default[this.findBestMatchLevelIndex(t._highlightResult.city.default)],t.administrative[this.findBestMatchLevelIndex(t._highlightResult.administrative)],null==(s=t.postcode)?void 0:s[this.findBestMatchLevelIndex(t._highlightResult.postcode)],null==(c=t.country)?void 0:c.default].filter(Boolean).join(", ")},n.parse=function(t){var e=this;return t.data.hits.map(function(a){return{x:a._geoloc.lng,y:a._geoloc.lat,label:e.getLabel(a),bounds:null,raw:a}})},n.search=function(t){var e=t.query;try{var a=this,s="string"==typeof e?{query:e}:e;return Promise.resolve(fetch(a.endpoint(),{method:"POST",body:JSON.stringify(l({},a.options.params,{},s))})).then(function(c){return Promise.resolve(c.json()).then(function(m){return a.parse({data:m})})})}catch(c){return Promise.reject(c)}}}(_),function(r){function o(){var t;return(t=r.apply(this,arguments)||this).searchUrl="https://dev.virtualearth.net/REST/v1/Locations",t}i(o,r);var n=o.prototype;n.endpoint=function(t){var e=t.query,a="string"==typeof e?{q:e}:e;return a.jsonp=t.jsonp,this.getUrl(this.searchUrl,a)},n.parse=function(t){return 0===t.data.resourceSets.length?[]:t.data.resourceSets[0].resources.map(function(e){return{x:e.point.coordinates[1],y:e.point.coordinates[0],label:e.address.formattedAddress,bounds:[[e.bbox[0],e.bbox[1]],[e.bbox[2],e.bbox[3]]],raw:e}})},n.search=function(t){var e,a,s,c=t.query;try{var m=this,C="BING_JSONP_CB_"+Date.now();return Promise.resolve((e=m.endpoint({query:c,jsonp:C}),a=C,s=v("script",null,document.body),s.setAttribute("type","text/javascript"),new Promise(function(U){window[a]=function(Y){s.remove(),delete window[a],U(Y)},s.setAttribute("src",e)}))).then(function(U){return m.parse({data:U})})}catch(U){return Promise.reject(U)}}}(_),function(r){function o(){var t;return(t=r.apply(this,arguments)||this).searchUrl="https://geocode.arcgis.com/arcgis/rest/services/World/GeocodeServer/find",t}i(o,r);var n=o.prototype;n.endpoint=function(t){var e=t.query,a="string"==typeof e?{text:e}:e;return a.f="json",this.getUrl(this.searchUrl,a)},n.parse=function(t){return t.data.locations.map(function(e){return{x:e.feature.geometry.x,y:e.feature.geometry.y,label:e.name,bounds:[[e.extent.ymin,e.extent.xmin],[e.extent.ymax,e.extent.xmax]],raw:e}})}}(_),function(r){function o(t){var e;return void 0===t&&(t={}),(e=r.call(this,t)||this).host=t.host||"http://localhost:4000",e}i(o,r);var n=o.prototype;return n.endpoint=function(t){var e=t.query;return t.type===w.REVERSE?this.getUrl(this.host+"/v1/reverse","string"==typeof e?{}:e):this.getUrl(this.host+"/v1/autocomplete","string"==typeof e?{text:e}:e)},n.parse=function(t){return t.data.features.map(function(e){var a={x:e.geometry.coordinates[0],y:e.geometry.coordinates[1],label:e.properties.label,bounds:null,raw:e};return Array.isArray(e.bbox)&&4===e.bbox.length&&(a.bounds=[[e.bbox[1],e.bbox[0]],[e.bbox[3],e.bbox[2]]]),a})},o}(_)),I=(function(r){i(function(n){return void 0===n&&(n={}),n.host="https://api.geocode.earth",r.call(this,n)||this},r)}(W),function(r){function o(){var t;return(t=r.apply(this,arguments)||this).searchUrl="https://maps.googleapis.com/maps/api/geocode/json",t}i(o,r);var n=o.prototype;n.endpoint=function(t){var e=t.query;return this.getUrl(this.searchUrl,"string"==typeof e?{address:e}:e)},n.parse=function(t){return t.data.results.map(function(e){return{x:e.geometry.location.lng,y:e.geometry.location.lat,label:e.formatted_address,bounds:[[e.geometry.viewport.southwest.lat,e.geometry.viewport.southwest.lng],[e.geometry.viewport.northeast.lat,e.geometry.viewport.northeast.lng]],raw:e}})}}(_),function(r){function o(){var t;return(t=r.apply(this,arguments)||this).searchUrl="https://geocode.search.hereapi.com/v1/geocode",t}i(o,r);var n=o.prototype;n.endpoint=function(t){var e=t.query;return this.getUrl(this.searchUrl,"string"==typeof e?{q:e}:e)},n.parse=function(t){return t.data.items.map(function(e){return{x:e.position.lng,y:e.position.lat,label:e.address.label,bounds:null,raw:e}})}}(_),function(r){function o(t){var e;void 0===t&&(t={});var a="https://nominatim.openstreetmap.org";return(e=r.call(this,t)||this).searchUrl=t.searchUrl||a+"/search",e.reverseUrl=t.reverseUrl||a+"/reverse",e}i(o,r);var n=o.prototype;return n.endpoint=function(t){var e=t.query,a=t.type,s="string"==typeof e?{q:e}:e;return s.format="json",this.getUrl(a===w.REVERSE?this.reverseUrl:this.searchUrl,s)},n.parse=function(t){return(Array.isArray(t.data)?t.data:[t.data]).map(function(e){return{x:Number(e.lon),y:Number(e.lat),label:e.display_name,bounds:[[parseFloat(e.boundingbox[0]),parseFloat(e.boundingbox[2])],[parseFloat(e.boundingbox[1]),parseFloat(e.boundingbox[3])]],raw:e}})},o}(_)),R=(function(r){i(function(n){return r.call(this,l({},n,{searchUrl:"https://locationiq.org/v1/search.php",reverseUrl:"https://locationiq.org/v1/reverse.php"}))||this},r)}(I),function(r){function o(){var t;return(t=r.apply(this,arguments)||this).searchUrl="https://api.opencagedata.com/geocode/v1/json",t}i(o,r);var n=o.prototype;n.endpoint=function(t){var e=t.query,a="string"==typeof e?{q:e}:e;return a.format="json",this.getUrl(this.searchUrl,a)},n.parse=function(t){return t.data.results.map(function(e){return{x:e.geometry.lng,y:e.geometry.lat,label:e.formatted,bounds:[[e.bounds.southwest.lat,e.bounds.southwest.lng],[e.bounds.northeast.lat,e.bounds.northeast.lng]],raw:e}})},n.search=function(t){try{return Promise.resolve(t.query.length<2?[]:r.prototype.search.call(this,t))}catch(e){return Promise.reject(e)}}}(_),function(r){function o(t){var e;return void 0===t&&(t={}),(e=r.call(this,t)||this).searchUrl=t.searchUrl||"https://a.tiles.mapbox.com/v4/geocode/mapbox.places/",e}i(o,r);var n=o.prototype;n.endpoint=function(t){return this.getUrl(""+this.searchUrl+t.query+".json")},n.parse=function(t){return(Array.isArray(t.data.features)?t.data.features:[]).map(function(e){var a=null;return e.bbox&&(a=[[parseFloat(e.bbox[1]),parseFloat(e.bbox[0])],[parseFloat(e.bbox[3]),parseFloat(e.bbox[2])]]),{x:Number(e.center[0]),y:Number(e.center[1]),label:e.place_name?e.place_name:e.text,bounds:a,raw:e}})}}(_),function(r){function o(t){var e;void 0===t&&(t={});var a="https://api-adresse.data.gouv.fr";return(e=r.call(this,t)||this).searchUrl=t.searchUrl||a+"/search",e.reverseUrl=t.reverseUrl||a+"/reverse",e}i(o,r);var n=o.prototype;n.endpoint=function(t){var e=t.query;return this.getUrl(t.type===w.REVERSE?this.reverseUrl:this.searchUrl,"string"==typeof e?{q:e}:e)},n.parse=function(t){return t.data.features.map(function(e){return{x:e.geometry.coordinates[0],y:e.geometry.coordinates[1],label:e.properties.label,bounds:null,raw:e}})}}(_),f(8966)),d=f(5e3),z=f(7423);const Z="assets/images/leaflet/marker-icon-2x.png",S="assets/images/leaflet/marker-shadow.png",j=h.icon({iconRetinaUrl:Z,iconUrl:"assets/images/leaflet/location_green.png",shadowUrl:S,iconSize:[23,33],iconAnchor:[16,33],popupAnchor:[1,-34],tooltipAnchor:[16,-28],shadowSize:[33,33]});h.icon({iconRetinaUrl:Z,iconUrl:"assets/images/leaflet/truck_green.png",shadowUrl:S,iconSize:[33,33],iconAnchor:[16,33],popupAnchor:[1,-34],tooltipAnchor:[16,-28],shadowSize:[33,33]}),h.icon({iconRetinaUrl:Z,iconUrl:"assets/images/leaflet/location_red.png",shadowUrl:S,iconSize:[23,32],iconAnchor:[12,32],popupAnchor:[1,-34],tooltipAnchor:[16,-28],shadowSize:[32,32]});let J=(()=>{class r{constructor(n,t){this.data=n,this.dialogRef=t,this.lat=28.1045642,this.lon=-26.3296247,this.label="",n&&(this.lat=n.lat,this.lon=n.lon,this.label=n.label)}initMap(){this.mapAddress=h.map("mapAddress",{center:[this.lon,this.lat],zoom:14});const n=h.tileLayer("https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png",{maxZoom:18,minZoom:3,attribution:'&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>'});let e=function(){if(!h)throw new Error(N);for(var r=h.Control.extend(F),o=arguments.length,n=new Array(o),t=0;t<o;t++)n[t]=arguments[t];return T(r,n)}({provider:new I({params:{countrycodes:"za",addressdetails:1,extratags:1,namedetails:1,pretty:1}}),style:"bar",showMarker:!0,showPopup:!1,marker:{icon:j,draggable:!1},popupFormat:({result:s})=>s.label,resultFormat:({result:a})=>a.label,maxMarkers:1,retainZoomLevel:!1,animateZoom:!0,autoClose:!1,searchLabel:"Enter address",keepResult:!1,updateMap:!0});h.marker([this.lon,this.lat],{icon:j}).addTo(this.mapAddress).bindPopup(this.label),this.mapAddress.addControl(e),this.mapAddress.on("geosearch/showlocation",a=>{this.location=a.location,console.log(a)}),n.addTo(this.mapAddress)}ngOnInit(){}ngAfterViewInit(){this.initMap()}cancel(){this.dialogRef.close(null)}submit(){this.dialogRef.close(this.location)}}return r.\u0275fac=function(n){return new(n||r)(d.Y36(R.WI),d.Y36(R.so))},r.\u0275cmp=d.Xpm({type:r,selectors:[["app-address"]],decls:12,vars:0,consts:[["mat-dialog-title","",1,"accent","dialog-title","bg-primary","text-on-primary","text-secondary",2,"margin-bottom","0px !important"],["mat-dialog-content","",2,"padding","0!important"],[1,"map-container"],[1,"map-frame"],["id","mapAddress"],["mat-dialog-actions","",1,"dialog-footer",2,"margin-top","0px !important"],[2,"flex","1 1 auto"],["mat-raised-button","","color","warn",3,"click"],["mat-raised-button","","color","primary",3,"click"]],template:function(n,t){1&n&&(d.TgZ(0,"h1",0),d._uU(1,"Select Address"),d.qZA(),d.TgZ(2,"div",1),d.TgZ(3,"div",2),d.TgZ(4,"div",3),d._UZ(5,"div",4),d.qZA(),d.qZA(),d.qZA(),d.TgZ(6,"div",5),d._UZ(7,"span",6),d.TgZ(8,"button",7),d.NdJ("click",function(){return t.cancel()}),d._uU(9,"Cancel"),d.qZA(),d.TgZ(10,"button",8),d.NdJ("click",function(){return t.submit()}),d._uU(11,"Submit"),d.qZA(),d.qZA())},directives:[R.uh,R.xY,R.H8,z.lW],styles:[".map-container[_ngcontent-%COMP%]{position:relative;top:0;left:0;right:0;bottom:0;height:50vh;min-height:200px}.map-frame[_ngcontent-%COMP%], #mapAddress[_ngcontent-%COMP%]{height:100%}"]}),r})()},7738:(O,M,f)=>{f.d(M,{_:()=>w});var h=f(7295),l=f(7579),i=f(5e3),g=f(8966),E=f(9808),T=f(7423);function v(p,y){if(1&p){const u=i.EpF();i.TgZ(0,"webcam",11),i.NdJ("imageCapture",function(A){return i.CHM(u),i.oxw(2).handleImage(A)}),i.qZA()}if(2&p){const u=i.oxw(2);i.Q6J("height",500)("width",1e3)("trigger",u.triggerObservable)("switchCamera",u.nextWebcamObservable)}}function k(p,y){if(1&p&&(i.TgZ(0,"ul"),i.TgZ(1,"li"),i._uU(2),i.ALo(3,"json"),i.qZA(),i.qZA()),2&p){const u=y.$implicit;i.xp6(2),i.Oqu(i.lcZ(3,1,u))}}function L(p,y){if(1&p&&(i.TgZ(0,"div"),i.TgZ(1,"h4"),i._uU(2,"Error Messages:"),i.qZA(),i.YNc(3,k,4,3,"ul",12),i.qZA()),2&p){const u=i.oxw(2);i.xp6(3),i.Q6J("ngForOf",u.errors)}}function x(p,y){if(1&p&&(i.TgZ(0,"div"),i.TgZ(1,"div",8),i.YNc(2,v,1,4,"webcam",9),i.qZA(),i.YNc(3,L,4,1,"div",10),i.qZA()),2&p){const u=i.oxw();i.xp6(2),i.Q6J("ngIf",u.showWebcam),i.xp6(1),i.Q6J("ngIf",u.errors.length>0)}}function b(p,y){1&p&&i._uU(0," Camera device not available ")}let w=(()=>{class p{constructor(u){this.dialogRef=u,this.showWebcam=!0,this.isCameraExist=!0,this.errors=[],this.trigger=new l.x,this.nextWebcam=new l.x}ngOnInit(){h.BF.getAvailableVideoInputs().then(u=>{this.isCameraExist=u&&u.length>0})}takeSnapshot(){this.trigger.next()}onOffWebCame(){this.showWebcam=!this.showWebcam}handleInitError(u){this.errors.push(u)}changeWebCame(u){this.nextWebcam.next(u)}handleImage(u){this.dialogRef.close(u)}get triggerObservable(){return this.trigger.asObservable()}get nextWebcamObservable(){return this.nextWebcam.asObservable()}cancel(){this.dialogRef.close(null)}}return p.\u0275fac=function(u){return new(u||p)(i.Y36(g.so))},p.\u0275cmp=i.Xpm({type:p,selectors:[["app-camera"]],decls:12,vars:2,consts:[["mat-dialog-title","",1,"accent","dialog-title","bg-primary","text-on-primary","text-secondary",2,"margin-bottom","0px !important"],["mat-dialog-content","",2,"padding","0!important"],[4,"ngIf","ngIfElse"],["noCameraExist",""],["mat-dialog-actions","",1,"dialog-footer",2,"margin-top","0px !important"],[2,"flex","1 1 auto"],["mat-raised-button","","color","warn",3,"click"],["mat-raised-button","","color","primary",3,"click"],[2,"text-align","center"],[3,"height","width","trigger","switchCamera","imageCapture",4,"ngIf"],[4,"ngIf"],[3,"height","width","trigger","switchCamera","imageCapture"],[4,"ngFor","ngForOf"]],template:function(u,P){if(1&u&&(i.TgZ(0,"h1",0),i._uU(1,"Take Photo"),i.qZA(),i.TgZ(2,"div",1),i.YNc(3,x,4,2,"div",2),i.YNc(4,b,1,0,"ng-template",null,3,i.W1O),i.qZA(),i.TgZ(6,"div",4),i._UZ(7,"span",5),i.TgZ(8,"button",6),i.NdJ("click",function(){return P.cancel()}),i._uU(9,"Cancel"),i.qZA(),i.TgZ(10,"button",7),i.NdJ("click",function(){return P.takeSnapshot()}),i._uU(11,"Take Photo"),i.qZA(),i.qZA()),2&u){const A=i.MAs(5);i.xp6(3),i.Q6J("ngIf",P.isCameraExist)("ngIfElse",A)}},directives:[g.uh,g.xY,E.O5,g.H8,T.lW,h.i3,E.sg],pipes:[E.Ts],styles:[".button[_ngcontent-%COMP%]{color:#fff;background-color:#00f;padding:4px;text-align:center;text-decoration:none;display:inline-block;font-size:16px;margin:4px 2px;transition-duration:.4s;cursor:pointer;border-radius:2px}ul.links[_ngcontent-%COMP%]{padding-bottom:10px}"]}),p})()},3098:(O,M)=>{var h=function(){function l(i){if(!i)throw new TypeError("Invalid argument; `value` has no value.");this.value=l.EMPTY,i&&l.isGuid(i)&&(this.value=i)}return l.isGuid=function(i){var g=i.toString();return i&&(i instanceof l||l.validator.test(g))},l.create=function(){return new l([l.gen(2),l.gen(1),l.gen(1),l.gen(1),l.gen(3)].join("-"))},l.createEmpty=function(){return new l("emptyguid")},l.parse=function(i){return new l(i)},l.raw=function(){return[l.gen(2),l.gen(1),l.gen(1),l.gen(1),l.gen(3)].join("-")},l.gen=function(i){for(var g="",E=0;E<i;E++)g+=(65536*(1+Math.random())|0).toString(16).substring(1);return g},l.prototype.equals=function(i){return l.isGuid(i)&&this.value===i.toString()},l.prototype.isEmpty=function(){return this.value===l.EMPTY},l.prototype.toString=function(){return this.value},l.prototype.toJSON=function(){return{value:this.value}},l.validator=new RegExp("^[a-z0-9]{8}-[a-z0-9]{4}-[a-z0-9]{4}-[a-z0-9]{4}-[a-z0-9]{12}$","i"),l.EMPTY="00000000-0000-0000-0000-000000000000",l}();M.i=h}}]);