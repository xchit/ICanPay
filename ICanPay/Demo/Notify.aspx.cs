﻿using ICanPay;
using System;
using System.Collections.Generic;

namespace Demo
{
    public partial class Notify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 设置商户数据
            Merchant alipayMerchant = new Merchant();
            alipayMerchant.GatewayType = GatewayType.Alipay;
            alipayMerchant.UserName = "000000000000000";    // 合作伙伴身份（PID）
            alipayMerchant.Key = "000000000000000000000000000000000000000000";  // MD5密钥

            Merchant yeepayMerchant = new Merchant();
            yeepayMerchant.GatewayType = GatewayType.Yeepay;
            yeepayMerchant.UserName = "000000000000000";    // 商户编号
            yeepayMerchant.Key = "000000000000000000000000000000000000000000";  // 商户密钥

            Merchant tenpayMerchant = new Merchant();
            tenpayMerchant.GatewayType = GatewayType.Tenpay;
            tenpayMerchant.UserName = "000000000000000";    // 商户号
            tenpayMerchant.Key = "000000000000000000000000000000000000000000";  // 密钥

            Merchant weChatPaymentMerchant = new Merchant();
            weChatPaymentMerchant.GatewayType = GatewayType.WeChatPay;
            weChatPaymentMerchant.UserName = "000000000000000"; // 微信支付商户号
            weChatPaymentMerchant.Key = "000000000000000000000000000000000000000000";   // API密钥

            // 添加到商户数据集合
            List<Merchant> merchantList = new List<Merchant>();
            merchantList.Add(alipayMerchant);
            merchantList.Add(yeepayMerchant);
            merchantList.Add(tenpayMerchant);
            merchantList.Add(weChatPaymentMerchant);

            // 订阅支付通知事件
            PaymentNotify notify = new PaymentNotify(merchantList);
            notify.PaymentSucceed += notify_PaymentSucceed;
            notify.PaymentFailed += notify_PaymentFailed;
            notify.UnknownGateway += notify_UnknownGateway;

            // 接收并处理支付通知
            notify.Received();
        }

        private void notify_PaymentSucceed(object sender, PaymentSucceedEventArgs e)
        {
            // 支付成功时时的处理代码

            if (e.PaymentNotifyMethod == PaymentNotifyMethod.AutoReturn)
            {
                // 当是用户的浏览器自动返回时显示支付成功页面
            }
        }

        private void notify_PaymentFailed(object sender, PaymentFailedEventArgs e)
        {
            // 支付失败时的处理代码
        }

        private void notify_UnknownGateway(object sender, UnknownGatewayEventArgs e)
        {
            // 无法识别支付网关时的处理代码
        }
    }
}
