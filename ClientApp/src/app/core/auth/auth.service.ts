import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError, Observable, of, switchMap, throwError } from 'rxjs';
import { AuthUtils } from 'app/core/auth/auth.utils';
import { UserService } from 'app/core/user/user.service';
import { Router } from '@angular/router';

@Injectable()
export class AuthService {
    private _authenticated: boolean = false;
    private baseUrl: string;

    /**
     * Constructor
     */
    constructor(
        private _httpClient: HttpClient,
        private _userService: UserService,
        private _router: Router,
        @Inject('BASE_URL') _baseUrl: string
    ) {
        this.baseUrl = _baseUrl;
        // localStorage.removeItem('accessToken')
        // localStorage.removeItem('userId');
        // localStorage.removeItem('email');
        // localStorage.removeItem('user');
        // localStorage.removeItem('accessToken');
        // this._authenticated = false;
    }

    // -----------------------------------------------------------------------------------------------------
    // @ Accessors
    // -----------------------------------------------------------------------------------------------------

    /**
     * Setter & getter for access token
     */
    set accessToken(token: string) {
        localStorage.setItem('accessToken', token);
    }

    get accessToken(): string {
        return localStorage.getItem('accessToken') ?? '';
    }

    // -----------------------------------------------------------------------------------------------------
    // @ Public methods
    // -----------------------------------------------------------------------------------------------------

    /**
     * Forgot password
     *
     * @param email
     */
    forgotPassword(email: string): Observable<any> {
        return this._httpClient.post(this.baseUrl + 'api/token/forgot-password?email=' +  email, email);
    }

    /**
     * Reset password
     *
     * @param password
     */
    resetPassword(reset: string, password: string): Observable<any> {
        return this._httpClient.post(this.baseUrl + 'api/token/reset-password', { reset: reset, password: password });
    }

    /**
     * Sign in
     *
     * @param credentials
     */
    signIn(credentials: { email: string; password: string }): Observable<any> {
        // Throw error, if the user is already logged in
        if (this._authenticated) {
            return throwError('User is already logged in.');
        }

        return this._httpClient.post(this.baseUrl + 'api/token', credentials).pipe(
            switchMap((response: any) => {
                console.log('response', response);

                // Store the access token in the local storage
                this.accessToken = response.accessToken;
                localStorage.setItem('accessToken', this.accessToken);
                localStorage.setItem('userId', response.user.userId);
                localStorage.setItem('email', credentials.email);
                localStorage.setItem('user', JSON.stringify(response.user));

                // Set the authenticated flag to true
                this._authenticated = true;

                // Store the user on the user service
                this._userService.user = response.user;

                // Return a new observable with the response
                return of(response);
            })
        );
    }

    /**
     * Sign in using the access token
     */
    signInUsingToken(): Observable<any> {
        // Renew token
        return this._httpClient.post(this.baseUrl + 'api/token/refresh', {
            email: localStorage.getItem('email'),
            accessToken: this.accessToken
        }).pipe(
            catchError(() =>

                // Return false
                of(false)
            ),
            switchMap((response: any) => {
                console.log('response', response);

                // Store the access token in the local storage
                this.accessToken = response.accessToken;
                localStorage.setItem('accessToken', this.accessToken);
                localStorage.setItem('userId', response.user.userId);
                localStorage.setItem('user', JSON.stringify(response.user))

                // Set the authenticated flag to true
                this._authenticated = true;

                // Store the user on the user service
                this._userService.user = response.user;

                // Return true
                return of(true);
            })
        );
    }

    /**
     * Sign out
     */
    signOut(): Observable<any> {
        // Remove the access token from the local storage
        localStorage.removeItem('accessToken');
        localStorage.removeItem('userId');
        localStorage.removeItem('user');
        this._authenticated = false;

        // Set the authenticated flag to false
        this._authenticated = false;

        // Return the observable
        return of(true);
    }

    /**
     * Sign up
     *
     * @param user
     */
    signUp(user: { company: string; firstName: string; lastName: string; phone: string; email: string; password: string, vehicles: boolean, loads: boolean, bids: boolean }): Observable<any> {
        return this._httpClient.post(this.baseUrl + 'api/users', user);
    }

    /**
     * Unlock session
     *
     * @param credentials
     */
    unlockSession(credentials: { email: string; password: string }): Observable<any> {
        return this._httpClient.post(this.baseUrl + 'api/token/unlock-session', credentials);
    }

    /**
     * Check the authentication status
     */
    check(): Observable<boolean> {
        // Check if the user is logged in
        if (this._authenticated) {
            return of(true);
        }

        // Check the access token availability
        if (!this.accessToken) {
            return of(false);
        }

        // Check the access token expire date
        if (AuthUtils.isTokenExpired(this.accessToken)) {
            localStorage.removeItem('accessToken');
            localStorage.removeItem('userId');
            localStorage.removeItem('user');
            this._router.navigateByUrl('/home');
            return of(false);
        }

        // If the access token exists and it didn't expire, sign in using it
        return this.signInUsingToken();
    }
}
