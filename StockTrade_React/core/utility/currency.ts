export const formatMoney = (
  currency: string = 'USD',
  value: number,
): string => {
  const currencyFormatter = new Intl.NumberFormat('en-US', {
    style: 'currency',
    currency: currency,
  });

  return currencyFormatter.format(value);
};
