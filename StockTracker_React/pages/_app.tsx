import React, { useState } from 'react';
// nextjs
import Router from 'next/router';
import { Provider as ClientProvider, useSession } from 'next-auth/client';
import type { AppProps } from 'next/app';
// next-auth
// components
import NextNProgress from 'nextjs-progressbar';
import { Header } from '@components/Layout/V1/Header/header';
import { Sidebar } from '@components/Layout/V1/Sidebar/Sidebar';
import { wrapper } from '../store/store';
import { CookiesProvider } from 'react-cookie';
import { LookupListContextProvider } from 'store/lookupList-context';
import { AppStateContextProvider } from 'store/appState-context';
import { LoginPage } from './api/auth/LoginPage/LoginPage';
// models
// services

function MyApp({ Component, pageProps }: AppProps) {
  const [showProcessing, setShowProcessing] = useState(false);
  const [session, loading] = useSession();

  Router.events.on('routeChangeStart', (url) => {
    setShowProcessing(true);
  });

  Router.events.on('routeChangeComplete', () => {
    setShowProcessing(false);
  });

  Router.events.on('routeChangeError', () => {
    setShowProcessing(false);
  });

  if (!session) {
    console.log('no session');
  }

  console.log('MyApp->session', session);

  return (
    <>
      {session ? (
        <LookupListContextProvider>
          <AppStateContextProvider>
            <CookiesProvider />
            <ClientProvider session={pageProps.session}>
              <NextNProgress />
              <Header />

              <main role='main' className='flex'>
                <Sidebar />
                <Component {...pageProps} />
              </main>
            </ClientProvider>
          </AppStateContextProvider>
        </LookupListContextProvider>
      ) : (
        <>
          <div className='container-login'>
            <LoginPage />
          </div>
        </>
      )}
    </>
  );
}

export default wrapper.withRedux(MyApp);
