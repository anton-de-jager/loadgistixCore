"use strict";(self.webpackChunkloadgistix=self.webpackChunkloadgistix||[]).push([[250],{5250:(T,c,o)=>{o.r(c),o.d(c,{AuthSignOutModule:()=>y});var s=o(4521),l=o(7423),g=o(6236),r=o(7776),d=o(7579),m=o(5963),h=o(8746),x=o(2529),f=o(2722),p=o(8505),t=o(5e3),v=o(8951),a=o(9808);function A(n,u){if(1&n&&(t.ynx(0),t._uU(1),t.ALo(2,"i18nPlural"),t.BQk()),2&n){const i=t.oxw();t.xp6(1),t.hij(" Redirecting in ",t.xi3(2,1,i.countdown,i.countdownMapping)," ")}}function Z(n,u){1&n&&(t.ynx(0),t._uU(1," You are now being redirected! "),t.BQk())}const S=function(){return["/sign-in"]},O=[{path:"",component:(()=>{class n{constructor(i,e){this._authService=i,this._router=e,this.countdown=5,this.countdownMapping={"=1":"# second",other:"# seconds"},this._unsubscribeAll=new d.x}ngOnInit(){this._authService.signOut(),(0,m.H)(1e3,1e3).pipe((0,h.x)(()=>{this._router.navigate(["sign-in"])}),(0,x.o)(()=>this.countdown>0),(0,f.R)(this._unsubscribeAll),(0,p.b)(()=>this.countdown--)).subscribe()}ngOnDestroy(){this._unsubscribeAll.next(null),this._unsubscribeAll.complete()}}return n.\u0275fac=function(i){return new(i||n)(t.Y36(v.e),t.Y36(s.F0))},n.\u0275cmp=t.Xpm({type:n,selectors:[["auth-sign-out"]],decls:15,vars:4,consts:[[1,"flex","flex-col","flex-auto","items-center","sm:justify-center","min-w-0"],[1,"w-full","sm:w-auto","py-8","px-4","sm:p-12","sm:rounded-2xl","sm:shadow","sm:bg-card"],[1,"w-full","max-w-80","sm:w-80","mx-auto","sm:mx-0"],[1,"w-100-p"],["src","assets/images/logo/loadgistix.png"],[1,"mt-8","text-4xl","font-extrabold","tracking-tight","leading-tight","text-center"],[1,"flex","justify-center","mt-0.5","font-medium"],[4,"ngIf"],[1,"mt-8","text-md","font-medium","text-secondary","text-center"],[1,"ml-1","text-primary-500","hover:underline",3,"routerLink"]],template:function(i,e){1&i&&(t.TgZ(0,"div",0),t.TgZ(1,"div",1),t.TgZ(2,"div",2),t.TgZ(3,"div",3),t._UZ(4,"img",4),t.qZA(),t.TgZ(5,"div",5),t._uU(6,"You have signed out!"),t.qZA(),t.TgZ(7,"div",6),t.YNc(8,A,3,4,"ng-container",7),t.YNc(9,Z,2,0,"ng-container",7),t.qZA(),t.TgZ(10,"div",8),t.TgZ(11,"span"),t._uU(12,"Go to"),t.qZA(),t.TgZ(13,"a",9),t._uU(14,"sign in "),t.qZA(),t.qZA(),t.qZA(),t.qZA(),t.qZA()),2&i&&(t.xp6(8),t.Q6J("ngIf",e.countdown>0),t.xp6(1),t.Q6J("ngIf",0===e.countdown),t.xp6(4),t.Q6J("routerLink",t.DdM(3,S)))},directives:[a.O5,s.yS],pipes:[a.Gx],encapsulation:2}),n})()}];let y=(()=>{class n{}return n.\u0275fac=function(i){return new(i||n)},n.\u0275mod=t.oAB({type:n}),n.\u0275inj=t.cJS({imports:[[s.Bz.forChild(O),l.ot,g.J,r.m]]}),n})()}}]);