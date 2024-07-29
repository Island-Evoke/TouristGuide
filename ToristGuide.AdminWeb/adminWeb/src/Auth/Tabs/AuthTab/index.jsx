import React, { Fragment } from "react";
import { Btn, H4, Image, P } from "../../../AbstractElements";
import authImg from "../../../assets/images/auth-img.svg";

const AuthTab = () => {
  return (
    <Fragment>
      <div className="auth-content">
        <Image attrImage={{ src: `${authImg}`, alt: "" }} />
        <H4>{"Welcome to login with Auth0"}</H4>
        <P>{"From improving customer experience through seamless sign-on to making MFA as easy as a click of a button – your login box must find the right balance between user convenience, privacy and security."}</P>
        {/* <Btn attrBtn={{ color: 'info', onClick: loginWithRedirect }}>{AUTH0}</Btn> */}
      </div>
    </Fragment>
  );
};

export default AuthTab;
